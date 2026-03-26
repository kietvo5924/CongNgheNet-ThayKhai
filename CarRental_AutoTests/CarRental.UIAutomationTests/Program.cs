using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;
using System.Text.RegularExpressions;
using System.Threading;
using System.Web.Script.Serialization;
using System.Windows.Automation;

namespace CarRental.UIAutomationTests
{
    internal class Program
    {
        [DllImport("user32.dll")]
        private static extern bool SetForegroundWindow(IntPtr hWnd);

        [STAThread]
        private static int Main(string[] args)
        {
            try
            {
                var settingsPath = args.Length > 0 ? args[0] : Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "testsettings.json");
                var settings = LoadSettings(settingsPath);
                var settingsDirectory = Path.GetDirectoryName(Path.GetFullPath(settingsPath));
                settings.ApplicationPath = ResolvePath(settings.ApplicationPath, settingsDirectory);

                if (!File.Exists(settings.ApplicationPath))
                {
                    return Fail("[FAIL] Không tìm th?y file ?ng d?ng: " + settings.ApplicationPath, 2);
                }

                if (settings.Scenarios == null)
                    settings.Scenarios = new List<TestScenario>();

                var activeScenarios = settings.Scenarios.Where(s => s != null && s.Enabled).ToList();
                if (!activeScenarios.Any())
                {
                    Console.WriteLine("Không có scenario nào ?ang b?t.");
                    return 0;
                }

                var failures = new List<string>();

                foreach (var scenario in activeScenarios)
                {
                    string failure;
                    using (var process = StartApplication(settings.ApplicationPath))
                    {
                        if (process == null)
                        {
                            failure = "Không th? kh?i ??ng ?ng d?ng.";
                        }
                        else
                        {
                            Thread.Sleep(settings.StartupWaitMs);
                            failure = ExecuteScenario(process.Id, settings, scenario);
                            TryCloseProcess(process);
                        }
                    }

                    if (failure == null)
                    {
                        Pass(scenario.Name);
                    }
                    else
                    {
                        Fail(scenario.Name + " -> " + failure, 1, false);
                        failures.Add(scenario.Name + ": " + failure);
                    }
                }

                Console.WriteLine();
                if (failures.Any())
                {
                    Console.WriteLine("T?ng k?t: " + failures.Count + " test fail.");
                    return 1;
                }

                Console.WriteLine("T?ng k?t: t?t c? test ??u pass.");
                return 0;
            }
            catch (Exception ex)
            {
                return Fail("[ERROR] " + ex.Message + Environment.NewLine + ex.StackTrace, 3);
            }
        }

        private static Process StartApplication(string appPath)
        {
            return Process.Start(new ProcessStartInfo
            {
                FileName = appPath,
                WorkingDirectory = Path.GetDirectoryName(appPath)
            });
        }

        private static string ExecuteScenario(int processId, TestSettings settings, TestScenario scenario)
        {
            var context = new ExecutionContext
            {
                ProcessId = processId,
                TimeoutMs = scenario.WindowSearchTimeoutMs > 0 ? scenario.WindowSearchTimeoutMs : settings.WindowSearchTimeoutMs,
                Variables = settings.Variables ?? new Dictionary<string, string>(StringComparer.OrdinalIgnoreCase)
            };

            var currentWindow = WaitForWindow(processId, scenario.WindowTitlePattern, context.TimeoutMs);
            if (currentWindow == null)
            {
                return "Không tìm th?y window ??u vào c?a scenario.";
            }

            foreach (var step in scenario.Steps ?? new List<TestStep>())
            {
                var error = ExecuteStep(context, ref currentWindow, step);
                if (error != null && !step.Optional)
                {
                    return "Step '" + step.Name + "' l?i: " + error;
                }
            }

            foreach (var assertion in scenario.Assertions ?? new List<TestAssertion>())
            {
                var error = EvaluateAssertion(context, currentWindow, assertion);
                if (error != null)
                {
                    return "Assertion '" + assertion.Name + "' l?i: " + error;
                }
            }

            return null;
        }

        private static string ExecuteStep(ExecutionContext context, ref AutomationElement currentWindow, TestStep step)
        {
            if (step == null || string.IsNullOrWhiteSpace(step.Action))
                return null;

            var action = step.Action.Trim().ToLowerInvariant();
            var timeoutMs = step.TimeoutMs > 0 ? step.TimeoutMs : context.TimeoutMs;
            var value = ResolveValue(step.Value, context.Variables);

            if (!string.IsNullOrWhiteSpace(step.WindowTitlePattern))
            {
                var targetWindow = WaitForWindow(context.ProcessId, ResolveValue(step.WindowTitlePattern, context.Variables), timeoutMs);
                if (targetWindow == null)
                    return "Không tìm th?y window theo pattern: " + step.WindowTitlePattern;
                currentWindow = targetWindow;
            }

            if (action == "wait")
            {
                Thread.Sleep(ParseInt(value, 500));
                return null;
            }

            if (action == "switchwindow")
            {
                var nextWindow = WaitForWindow(context.ProcessId, value, timeoutMs);
                if (nextWindow == null)
                    return "Không chuy?n ???c sang window: " + value;
                currentWindow = nextWindow;
                FocusWindow(currentWindow);
                return null;
            }

            if (action == "clickdialogbutton")
            {
                var dialog = WaitForWindow(context.ProcessId, ResolveValue(step.WindowTitlePattern, context.Variables), timeoutMs);
                if (dialog == null)
                    return "Không th?y dialog ?? click button.";
                var button = FindElement(dialog, new TestLocator { Target = value, TargetBy = "Name", ControlType = "Button" }, 1000);
                if (button == null)
                    return "Không th?y button trong dialog: " + value;
                return ClickElement(button);
            }

            var element = FindElement(currentWindow, step, timeoutMs);
            if (element == null)
                return "Không tìm th?y control: " + step.Target;

            if (action == "click")
                return ClickElement(element);

            if (action == "doubleclick")
            {
                var clickError = ClickElement(element);
                if (clickError != null) return clickError;
                Thread.Sleep(120);
                return ClickElement(element);
            }

            if (action == "settext")
                return SetElementText(element, value);

            if (action == "togglecheckbox")
                return ToggleCheckBox(element, ParseBool(value, true));

            if (action == "sendkeys")
            {
                FocusWindow(currentWindow);
                element.SetFocus();
                return SendKeysToActiveWindow(value);
            }

            if (action == "selectcombobytext")
            {
                var clickError = ClickElement(element);
                if (clickError != null) return clickError;
                Thread.Sleep(120);
                return SendKeysToActiveWindow(EscapeSendKeysText(value) + "{ENTER}");
            }

            if (action == "selectfirstrow")
            {
                var row = element.FindFirst(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem));
                if (row == null)
                    return "Không tìm th?y dòng d? li?u nào.";
                return ClickElement(row);
            }

            if (action == "opencontextmenu")
            {
                FocusWindow(currentWindow);
                element.SetFocus();
                return SendKeysToActiveWindow("+{F10}");
            }

            if (action == "clickmenuitem")
            {
                var menuItem = FindElement(AutomationElement.RootElement,
                    new TestLocator { Target = value, TargetBy = "Name", ControlType = "MenuItem" }, timeoutMs);
                if (menuItem == null)
                    return "Không tìm th?y menu item: " + value;
                return ClickElement(menuItem);
            }

            return "Action ch?a h? tr?: " + step.Action;
        }

        private static string EvaluateAssertion(ExecutionContext context, AutomationElement currentWindow, TestAssertion assertion)
        {
            if (assertion == null || string.IsNullOrWhiteSpace(assertion.Type))
                return null;

            var type = assertion.Type.Trim().ToLowerInvariant();
            var timeoutMs = assertion.TimeoutMs > 0 ? assertion.TimeoutMs : context.TimeoutMs;
            var value = ResolveValue(assertion.Value, context.Variables);

            if (type == "windowexists")
            {
                var win = WaitForWindow(context.ProcessId, value, timeoutMs);
                return win == null ? "Không tìm th?y window theo pattern: " + value : null;
            }

            if (type == "windownotexists")
            {
                var win = WaitForWindow(context.ProcessId, value, 1500);
                return win != null ? "Window v?n t?n t?i: " + value : null;
            }

            var rootWindow = currentWindow;
            if (!string.IsNullOrWhiteSpace(assertion.WindowTitlePattern))
            {
                rootWindow = WaitForWindow(context.ProcessId, ResolveValue(assertion.WindowTitlePattern, context.Variables), timeoutMs);
                if (rootWindow == null)
                    return "Không tìm th?y window ch?a control assertion.";
            }

            var element = FindElement(rootWindow, assertion, timeoutMs);
            if (element == null)
                return "Không tìm th?y control: " + assertion.Target;

            if (type == "controlexists")
                return null;

            if (type == "controlenabled")
                return element.Current.IsEnabled ? null : "Control ?ang b? disable.";

            if (type == "controldisabled")
                return !element.Current.IsEnabled ? null : "Control v?n ?ang enable.";

            if (type == "controlvisible")
                return !element.Current.IsOffscreen ? null : "Control ?ang b? ?n.";

            if (type == "textcontains")
            {
                var text = GetElementText(element);
                return (text ?? string.Empty).IndexOf(value ?? string.Empty, StringComparison.OrdinalIgnoreCase) >= 0
                    ? null
                    : "Text không ch?a giá tr? mong ??i. Actual: " + text;
            }

            if (type == "gridrowcountmin")
            {
                var rows = element.FindAll(TreeScope.Descendants,
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.DataItem)).Count;
                var min = ParseInt(value, 1);
                return rows >= min ? null : "S? dòng hi?n có " + rows + ", yêu c?u >= " + min;
            }

            return "Assertion ch?a h? tr?: " + assertion.Type;
        }

        private static string SetElementText(AutomationElement element, string value)
        {
            object pattern;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
            {
                var valuePattern = (ValuePattern)pattern;
                if (!valuePattern.Current.IsReadOnly)
                {
                    valuePattern.SetValue(value ?? string.Empty);
                    return null;
                }
            }

            var clickError = ClickElement(element);
            if (clickError != null) return clickError;

            var clearError = SendKeysToActiveWindow("^a{BACKSPACE}");
            if (clearError != null) return clearError;

            return SendKeysToActiveWindow(EscapeSendKeysText(value));
        }

        private static string ToggleCheckBox(AutomationElement element, bool targetChecked)
        {
            object pattern;
            if (element.TryGetCurrentPattern(TogglePattern.Pattern, out pattern))
            {
                var toggle = (TogglePattern)pattern;
                var current = toggle.Current.ToggleState == ToggleState.On;
                if (current != targetChecked)
                    toggle.Toggle();
                return null;
            }

            return ClickElement(element);
        }

        private static string ClickElement(AutomationElement element)
        {
            try
            {
                object pattern;
                if (element.TryGetCurrentPattern(InvokePattern.Pattern, out pattern))
                {
                    ((InvokePattern)pattern).Invoke();
                    return null;
                }

                if (element.TryGetCurrentPattern(SelectionItemPattern.Pattern, out pattern))
                {
                    ((SelectionItemPattern)pattern).Select();
                    return null;
                }

                element.SetFocus();
                return SendKeysToActiveWindow("{ENTER}");
            }
            catch (Exception ex)
            {
                return "Click l?i: " + ex.Message;
            }
        }

        private static AutomationElement FindElement(AutomationElement scopeRoot, TestLocator locator, int timeoutMs)
        {
            if (scopeRoot == null)
                return null;

            var start = DateTime.UtcNow;
            while ((DateTime.UtcNow - start).TotalMilliseconds <= timeoutMs)
            {
                var found = FindElementOnce(scopeRoot, locator);
                if (found != null)
                    return found;
                Thread.Sleep(200);
            }

            return null;
        }

        private static AutomationElement FindElementOnce(AutomationElement scopeRoot, TestLocator locator)
        {
            if (locator == null)
                return null;

            var conditions = new List<Condition>();
            var controlType = ParseControlType(locator.ControlType);
            if (controlType != null)
                conditions.Add(new PropertyCondition(AutomationElement.ControlTypeProperty, controlType));

            var target = locator.Target ?? string.Empty;
            var targetBy = string.IsNullOrWhiteSpace(locator.TargetBy) ? "AutomationId" : locator.TargetBy;

            if (!string.IsNullOrWhiteSpace(target))
            {
                if (targetBy.Equals("Name", StringComparison.OrdinalIgnoreCase))
                    conditions.Add(new PropertyCondition(AutomationElement.NameProperty, target));
                else if (targetBy.Equals("ClassName", StringComparison.OrdinalIgnoreCase))
                    conditions.Add(new PropertyCondition(AutomationElement.ClassNameProperty, target));
                else
                    conditions.Add(new PropertyCondition(AutomationElement.AutomationIdProperty, target));
            }

            Condition condition = conditions.Count == 0
                ? Condition.TrueCondition
                : (conditions.Count == 1 ? conditions[0] : new AndCondition(conditions.ToArray()));

            return scopeRoot.FindFirst(TreeScope.Descendants, condition);
        }

        private static ControlType ParseControlType(string typeName)
        {
            if (string.IsNullOrWhiteSpace(typeName))
                return null;

            var name = typeName.Trim().ToLowerInvariant();
            if (name == "button") return ControlType.Button;
            if (name == "edit" || name == "textbox") return ControlType.Edit;
            if (name == "checkbox") return ControlType.CheckBox;
            if (name == "combobox") return ControlType.ComboBox;
            if (name == "menuitem") return ControlType.MenuItem;
            if (name == "datagrid" || name == "table") return ControlType.DataGrid;
            if (name == "dataitem" || name == "row") return ControlType.DataItem;
            if (name == "window") return ControlType.Window;
            if (name == "text" || name == "label") return ControlType.Text;
            return null;
        }

        private static AutomationElement WaitForWindow(int processId, string titlePattern, int timeoutMs)
        {
            var start = DateTime.UtcNow;
            while ((DateTime.UtcNow - start).TotalMilliseconds <= timeoutMs)
            {
                var windows = AutomationElement.RootElement.FindAll(TreeScope.Children,
                    new PropertyCondition(AutomationElement.ControlTypeProperty, ControlType.Window));

                foreach (AutomationElement window in windows)
                {
                    if (window.Current.ProcessId != processId)
                        continue;

                    var title = window.Current.Name ?? string.Empty;
                    if (IsTitleMatched(title, titlePattern))
                        return window;
                }

                Thread.Sleep(300);
            }

            return null;
        }

        private static void FocusWindow(AutomationElement window)
        {
            if (window == null)
                return;

            try
            {
                var handle = new IntPtr(window.Current.NativeWindowHandle);
                if (handle != IntPtr.Zero)
                    SetForegroundWindow(handle);
                window.SetFocus();
            }
            catch
            {
            }
        }

        private static string SendKeysToActiveWindow(string keys)
        {
            try
            {
                var shellType = Type.GetTypeFromProgID("WScript.Shell");
                if (shellType == null)
                    return "Không t?o ???c WScript.Shell ?? g?i phím.";

                var shell = Activator.CreateInstance(shellType);
                shellType.InvokeMember("SendKeys", BindingFlags.InvokeMethod, null, shell, new object[] { keys ?? string.Empty });
                return null;
            }
            catch (Exception ex)
            {
                return "SendKeys l?i: " + ex.Message;
            }
        }

        private static string EscapeSendKeysText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            var escaped = text
                .Replace("+", "{+}")
                .Replace("^", "{^}")
                .Replace("%", "{%}")
                .Replace("~", "{~}")
                .Replace("(", "{(}")
                .Replace(")", "{)}")
                .Replace("[", "{[}")
                .Replace("]", "{]}")
                .Replace("{", "{{}")
                .Replace("}", "{}}");

            return escaped;
        }

        private static string GetElementText(AutomationElement element)
        {
            object pattern;
            if (element.TryGetCurrentPattern(ValuePattern.Pattern, out pattern))
            {
                return ((ValuePattern)pattern).Current.Value;
            }

            return element.Current.Name;
        }

        private static void TryCloseProcess(Process process)
        {
            if (process == null || process.HasExited)
                return;

            process.CloseMainWindow();
            if (!process.WaitForExit(5000))
                process.Kill();
        }

        private static bool IsTitleMatched(string title, string pattern)
        {
            if (string.IsNullOrWhiteSpace(pattern))
                return true;

            try
            {
                return Regex.IsMatch(title ?? string.Empty, pattern, RegexOptions.IgnoreCase);
            }
            catch (ArgumentException)
            {
                var titleValue = (title ?? string.Empty).ToLowerInvariant();
                var keywords = pattern.Split(new[] { '|' }, StringSplitOptions.RemoveEmptyEntries);
                return keywords.Any(k => titleValue.Contains(k.Trim().ToLowerInvariant()));
            }
        }

        private static TestSettings LoadSettings(string settingsPath)
        {
            if (!File.Exists(settingsPath))
                throw new FileNotFoundException("Không tìm th?y file c?u hình test", settingsPath);

            var serializer = new JavaScriptSerializer();
            var json = File.ReadAllText(settingsPath);
            var settings = serializer.Deserialize<TestSettings>(json);
            if (settings == null)
                throw new InvalidOperationException("N?i dung c?u hình test không h?p l?.");

            return settings;
        }

        private static string ResolvePath(string path, string baseDirectory)
        {
            if (string.IsNullOrWhiteSpace(path))
                return path;

            return Path.IsPathRooted(path)
                ? path
                : Path.GetFullPath(Path.Combine(baseDirectory, path));
        }

        private static string ResolveValue(string input, IDictionary<string, string> variables)
        {
            if (string.IsNullOrWhiteSpace(input))
                return input;

            return Regex.Replace(input, "\\{\\{([A-Za-z0-9_]+)\\}\\}", match =>
            {
                var key = match.Groups[1].Value;
                string value;
                if (variables != null && variables.TryGetValue(key, out value))
                    return value ?? string.Empty;

                var fromEnv = Environment.GetEnvironmentVariable(key);
                return fromEnv ?? string.Empty;
            });
        }

        private static int ParseInt(string value, int defaultValue)
        {
            int number;
            return int.TryParse(value, NumberStyles.Integer, CultureInfo.InvariantCulture, out number) ? number : defaultValue;
        }

        private static bool ParseBool(string value, bool defaultValue)
        {
            bool result;
            return bool.TryParse(value, out result) ? result : defaultValue;
        }

        private static int Fail(string message, int code, bool printPrefix = true)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine(printPrefix ? "[FAIL] " + message : message);
            Console.ResetColor();
            return code;
        }

        private static void Pass(string message)
        {
            Console.ForegroundColor = ConsoleColor.Green;
            Console.WriteLine("[PASS] " + message);
            Console.ResetColor();
        }
    }

    internal class ExecutionContext
    {
        public int ProcessId { get; set; }
        public int TimeoutMs { get; set; }
        public IDictionary<string, string> Variables { get; set; }
    }

    public class TestSettings
    {
        public string ApplicationPath { get; set; }
        public int StartupWaitMs { get; set; }
        public int WindowSearchTimeoutMs { get; set; }
        public Dictionary<string, string> Variables { get; set; }
        public List<TestScenario> Scenarios { get; set; }
    }

    public class TestScenario
    {
        public string Name { get; set; }
        public bool Enabled { get; set; } = true;
        public string WindowTitlePattern { get; set; }
        public int WindowSearchTimeoutMs { get; set; }
        public List<TestStep> Steps { get; set; }
        public List<TestAssertion> Assertions { get; set; }
    }

    public class TestLocator
    {
        public string Target { get; set; }
        public string TargetBy { get; set; }
        public string ControlType { get; set; }
        public string WindowTitlePattern { get; set; }
        public int TimeoutMs { get; set; }
    }

    public class TestStep : TestLocator
    {
        public string Name { get; set; }
        public string Action { get; set; }
        public string Value { get; set; }
        public bool Optional { get; set; }
    }

    public class TestAssertion : TestLocator
    {
        public string Name { get; set; }
        public string Type { get; set; }
        public string Value { get; set; }
    }
}
