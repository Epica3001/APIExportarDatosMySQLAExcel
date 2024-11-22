using System.Data;
using ClosedXML.Excel;

namespace ExportarDatosAExcelAPI.Services
{
    public class ExcelExportService
    {
        public void ExportToExcel(DataTable dataTable, string filePath, string table)
        {
            using var workbook = new XLWorkbook();
            var worksheet = workbook.Worksheets.Add(table);
            worksheet.Cell(1, 1).InsertTable(dataTable);
            workbook.SaveAs(filePath);
        }
    }
}
