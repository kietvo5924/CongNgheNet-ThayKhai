using System;
using System.Collections.Generic;
using System.Data;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace CarRental.GlobalClasses
{
    public class clsUtil
    {
        public static string GenerateGUID()
        {

            // Generate a new GUID
            Guid newGuid = Guid.NewGuid();

            // convert the GUID to a string
            return newGuid.ToString();

        }

        public static bool CreateFolderIfDoesNotExist(string FolderPath)
        {

            // Check if the folder exists
            if (!Directory.Exists(FolderPath))
            {
                try
                {
                    // If it doesn't exist, create the folder
                    Directory.CreateDirectory(FolderPath);
                    return true;
                }
                catch (Exception ex)
                {
                    clsLogError.LogError("General Exception", ex);
                    return false;
                }
            }

            return true;

        }

        public static string ReplaceFileNameWithGUID(string sourceFile)
        {
            // Full file name. Change your file name   
            string fileName = sourceFile;
            FileInfo fi = new FileInfo(fileName);
            string extn = fi.Extension;
            return GenerateGUID() + extn;

        }

        public static bool CopyImageToProjectImagesFolder(ref string sourceFile)
        {
            // this function will copy the image to the
            // project images folder after renaming it
            // with GUID with the same extension, then it will update the sourceFileName with the new name.

            string DestinationFolder = @"D:\car-rental-user-images\";
            if (!CreateFolderIfDoesNotExist(DestinationFolder))
            {
                return false;
            }

            string destinationFile = DestinationFolder + ReplaceFileNameWithGUID(sourceFile);
            try
            {
                File.Copy(sourceFile, destinationFile, true);

            }
            catch (IOException iox)
            {
                clsLogError.LogError("IO Exception", iox);
                return false;
            }
            catch(Exception ex)
            {
                clsLogError.LogError("General Exception", ex);
                return false;
            }

            sourceFile = destinationFile;
            return true;
        }

        public static void ExportDataGridView(DataGridView grid, string defaultFileName, string reportTitle)
        {
            if (grid == null || grid.Columns.Count == 0)
            {
                MessageBox.Show("Không có dữ liệu để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            if (!_GetExportRows(grid).Any())
            {
                MessageBox.Show("Không có dữ liệu hiển thị để xuất.", "Thông báo", MessageBoxButtons.OK, MessageBoxIcon.Information);
                return;
            }

            using (SaveFileDialog saveDialog = new SaveFileDialog())
            {
                saveDialog.Title = "Xuất dữ liệu";
                saveDialog.FileName = defaultFileName + "_" + DateTime.Now.ToString("yyyyMMdd_HHmmss");
                saveDialog.Filter = "CSV (*.csv)|*.csv|Excel (*.xls)|*.xls|PDF (*.pdf)|*.pdf";
                saveDialog.DefaultExt = "csv";

                if (saveDialog.ShowDialog() != DialogResult.OK)
                    return;

                string extension = Path.GetExtension(saveDialog.FileName)?.ToLowerInvariant();

                try
                {
                    switch (extension)
                    {
                        case ".xls":
                            _ExportToExcelHtml(grid, saveDialog.FileName, reportTitle);
                            break;
                        case ".pdf":
                            _ExportToPdf(grid, saveDialog.FileName, reportTitle);
                            break;
                        default:
                            _ExportToCsv(grid, saveDialog.FileName);
                            break;
                    }

                    MessageBox.Show("Xuất dữ liệu thành công.", "Hoàn tất", MessageBoxButtons.OK, MessageBoxIcon.Information);
                }
                catch (Exception ex)
                {
                    MessageBox.Show("Xuất dữ liệu thất bại: " + ex.Message, "Lỗi", MessageBoxButtons.OK, MessageBoxIcon.Error);
                }
            }
        }

        private static List<DataGridViewColumn> _GetExportColumns(DataGridView grid)
        {
            return grid.Columns
                .Cast<DataGridViewColumn>()
                .Where(c => c.Visible)
                .OrderBy(c => c.DisplayIndex)
                .ToList();
        }

        private static IEnumerable<DataGridViewRow> _GetExportRows(DataGridView grid)
        {
            return grid.Rows.Cast<DataGridViewRow>().Where(r => !r.IsNewRow && r.Visible);
        }

        private static void _ExportToCsv(DataGridView grid, string filePath)
        {
            List<DataGridViewColumn> columns = _GetExportColumns(grid);
            List<DataGridViewRow> rows = _GetExportRows(grid).ToList();
            using (StreamWriter writer = new StreamWriter(filePath, false, new UTF8Encoding(true)))
            {
                writer.WriteLine($"Báo cáo: {DateTime.Now:dd/MM/yyyy HH:mm}");
                writer.WriteLine($"Tổng số bản ghi xuất: {rows.Count}");
                writer.WriteLine(string.Empty);
                writer.WriteLine(string.Join(",", columns.Select(c => _EscapeCsv(c.HeaderText))));

                foreach (DataGridViewRow row in rows)
                {
                    List<string> values = new List<string>();
                    foreach (DataGridViewColumn col in columns)
                    {
                        object value = row.Cells[col.Index].Value;
                        values.Add(_EscapeCsv(_FormatCellValue(value)));
                    }
                    writer.WriteLine(string.Join(",", values));
                }
            }
        }

        private static void _ExportToExcelHtml(DataGridView grid, string filePath, string reportTitle)
        {
            List<DataGridViewColumn> columns = _GetExportColumns(grid);
            List<DataGridViewRow> rows = _GetExportRows(grid).ToList();
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<html><head><meta charset='utf-8'></head><body>");
            sb.AppendLine($"<h2>{System.Net.WebUtility.HtmlEncode(reportTitle)}</h2>");
            sb.AppendLine($"<div>Thời gian xuất: {DateTime.Now:dd/MM/yyyy HH:mm}</div>");
            sb.AppendLine($"<div>Tổng số bản ghi xuất: {rows.Count}</div>");
            sb.AppendLine("<table border='1' cellspacing='0' cellpadding='4'>");
            sb.AppendLine("<tr style='font-weight:bold;background:#f3f4f6'>");

            foreach (DataGridViewColumn col in columns)
                sb.AppendLine($"<th>{System.Net.WebUtility.HtmlEncode(col.HeaderText)}</th>");

            sb.AppendLine("</tr>");

            foreach (DataGridViewRow row in rows)
            {
                sb.AppendLine("<tr>");
                foreach (DataGridViewColumn col in columns)
                {
                    object value = row.Cells[col.Index].Value;
                    sb.AppendLine($"<td>{System.Net.WebUtility.HtmlEncode(_FormatCellValue(value))}</td>");
                }
                sb.AppendLine("</tr>");
            }

            sb.AppendLine("</table></body></html>");
            File.WriteAllText(filePath, sb.ToString(), new UTF8Encoding(true));
        }

        private static void _ExportToPdf(DataGridView grid, string filePath, string reportTitle)
        {
            List<DataGridViewColumn> columns = _GetExportColumns(grid);
            List<DataGridViewRow> rows = _GetExportRows(grid).ToList();

            List<string> lines = new List<string>
            {
                _RemoveDiacritics(reportTitle),
                "Thoi gian xuat: " + DateTime.Now.ToString("dd/MM/yyyy HH:mm", CultureInfo.InvariantCulture),
                "Tong so ban ghi xuat: " + rows.Count,
                string.Empty,
                string.Join(" | ", columns.Select(c => _RemoveDiacritics(c.HeaderText))),
                new string('-', 120)
            };

            foreach (DataGridViewRow row in rows)
            {
                List<string> values = new List<string>();
                foreach (DataGridViewColumn col in columns)
                {
                    object value = row.Cells[col.Index].Value;
                    values.Add(_RemoveDiacritics(_FormatCellValue(value)));
                }

                lines.Add(string.Join(" | ", values));
            }

            _WriteSimplePdf(filePath, lines);
        }

        private static void _WriteSimplePdf(string filePath, List<string> lines)
        {
            const int maxLinesPerPage = 44;
            List<List<string>> pages = new List<List<string>>();

            for (int i = 0; i < lines.Count; i += maxLinesPerPage)
                pages.Add(lines.Skip(i).Take(maxLinesPerPage).ToList());

            int objectCount = 3 + pages.Count * 2;
            string[] objects = new string[objectCount + 1];

            StringBuilder kids = new StringBuilder();
            for (int i = 0; i < pages.Count; i++)
            {
                int pageObjNum = 4 + (i * 2);
                kids.AppendFormat("{0} 0 R ", pageObjNum);
            }

            objects[1] = "<< /Type /Catalog /Pages 2 0 R >>";
            objects[2] = $"<< /Type /Pages /Kids [{kids}] /Count {pages.Count} >>";
            objects[3] = "<< /Type /Font /Subtype /Type1 /BaseFont /Helvetica >>";

            for (int i = 0; i < pages.Count; i++)
            {
                int pageObjNum = 4 + (i * 2);
                int contentObjNum = pageObjNum + 1;
                string content = _BuildPageContent(pages[i]);
                byte[] contentBytes = Encoding.ASCII.GetBytes(content);

                objects[pageObjNum] = $"<< /Type /Page /Parent 2 0 R /MediaBox [0 0 595 842] /Resources << /Font << /F1 3 0 R >> >> /Contents {contentObjNum} 0 R >>";
                objects[contentObjNum] = $"<< /Length {contentBytes.Length} >>\nstream\n{content}\nendstream";
            }

            using (FileStream fs = new FileStream(filePath, FileMode.Create, FileAccess.Write))
            using (BinaryWriter bw = new BinaryWriter(fs, Encoding.ASCII))
            {
                bw.Write(Encoding.ASCII.GetBytes("%PDF-1.4\n"));

                List<long> offsets = new List<long> { 0 };

                for (int i = 1; i <= objectCount; i++)
                {
                    offsets.Add(fs.Position);
                    string obj = i + " 0 obj\n" + objects[i] + "\nendobj\n";
                    bw.Write(Encoding.ASCII.GetBytes(obj));
                }

                long xrefPosition = fs.Position;
                bw.Write(Encoding.ASCII.GetBytes($"xref\n0 {objectCount + 1}\n"));
                bw.Write(Encoding.ASCII.GetBytes("0000000000 65535 f \n"));

                for (int i = 1; i <= objectCount; i++)
                    bw.Write(Encoding.ASCII.GetBytes(offsets[i].ToString("D10") + " 00000 n \n"));

                string trailer = $"trailer\n<< /Size {objectCount + 1} /Root 1 0 R >>\nstartxref\n{xrefPosition}\n%%EOF";
                bw.Write(Encoding.ASCII.GetBytes(trailer));
            }
        }

        private static string _BuildPageContent(List<string> lines)
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("BT");
            sb.AppendLine("/F1 10 Tf");
            sb.AppendLine("40 810 Td");

            foreach (string line in lines)
            {
                string safe = _EscapePdfText(_TrimToLength(line, 140));
                sb.AppendLine($"({safe}) Tj");
                sb.AppendLine("0 -16 Td");
            }

            sb.AppendLine("ET");
            return sb.ToString();
        }

        private static string _TrimToLength(string text, int maxLength)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Length <= maxLength ? text : text.Substring(0, maxLength - 3) + "...";
        }

        private static string _EscapePdfText(string text)
        {
            if (string.IsNullOrEmpty(text))
                return string.Empty;

            return text.Replace("\\", "\\\\").Replace("(", "\\(").Replace(")", "\\)");
        }

        private static string _EscapeCsv(string input)
        {
            if (input == null)
                return string.Empty;

            if (input.Contains(",") || input.Contains("\"") || input.Contains("\n") || input.Contains("\r"))
                return "\"" + input.Replace("\"", "\"\"") + "\"";

            return input;
        }

        private static string _FormatCellValue(object value)
        {
            if (value == null || value == DBNull.Value)
                return string.Empty;

            if (value is DateTime dateTime)
                return dateTime.ToString("dd/MM/yyyy HH:mm", CultureInfo.CurrentCulture);

            if (value is bool boolean)
                return boolean ? "Có" : "Không";

            return Convert.ToString(value, CultureInfo.CurrentCulture) ?? string.Empty;
        }

        private static string _RemoveDiacritics(string text)
        {
            if (string.IsNullOrWhiteSpace(text))
                return string.Empty;

            string normalized = text.Normalize(NormalizationForm.FormD);
            StringBuilder sb = new StringBuilder();
            foreach (char c in normalized)
            {
                UnicodeCategory uc = CharUnicodeInfo.GetUnicodeCategory(c);
                if (uc != UnicodeCategory.NonSpacingMark)
                    sb.Append(c);
            }

            return Regex.Replace(sb.ToString().Normalize(NormalizationForm.FormC), "[^\u0020-\u007E]", "");
        }
    }
}
