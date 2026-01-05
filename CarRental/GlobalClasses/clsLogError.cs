using System;
using System.IO;

namespace CarRental.GlobalClasses
{
    public static class clsLogError
    {
        public static void LogError(string errorType, Exception ex)
        {
            string errorMessage = $"{errorType} in {ex.Source}\n\nException Message:" +
                    $" {ex.Message}\n\nException Type: {ex.GetType().Name}\n\nStack Trace:" +
                    $" {ex.StackTrace}\n\nException Location: {ex.TargetSite}";

            WriteToLocalFile(errorMessage);
        }

        private static void WriteToLocalFile(string message)
        {
            try
            {
                string logDirectory = Path.Combine(
                    Environment.GetFolderPath(Environment.SpecialFolder.LocalApplicationData),
                    "CarRental",
                    "Logs");

                Directory.CreateDirectory(logDirectory);

                string logFile = Path.Combine(logDirectory, $"errors-{DateTime.UtcNow:yyyyMMdd}.log");
                File.AppendAllText(logFile, $"[{DateTime.Now:O}] {message}{Environment.NewLine}{Environment.NewLine}");
            }
            catch
            {
                // Swallow logging failures silently.
            }
        }
    }
}
