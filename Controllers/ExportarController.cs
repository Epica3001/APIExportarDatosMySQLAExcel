using Microsoft.AspNetCore.Mvc;
using System.Data;
using ExportarDatosAExcelAPI.Helpers;
using ExportarDatosAExcelAPI.Services;
using System;

namespace ExportarDatosAExcelAPI.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class ExportarController : ControllerBase
    {
        private readonly DatabaseConnection _databaseConnection;
        private readonly DatabaseService _databaseService;
        private readonly ExcelExportService _excelExportService;

        public ExportarController(DatabaseConnection databaseConnection, DatabaseService databaseService, ExcelExportService excelExportService)
        {
            _databaseConnection = databaseConnection;
            _databaseService = databaseService;
            _excelExportService = excelExportService;
        }

        [HttpGet("{table}")]
        public IActionResult ExportarDatosAExcel(string table)
        {
            string connectionString = _databaseConnection.GetConnectionString();
            string query = $"SELECT * FROM {table}";
            string filePath = $"{table}_Export.xlsx";

            try
            {
                DataTable dataTable = _databaseService.ExecuteQuery(query);
                if (dataTable.Rows.Count > 0)
                {
                    _excelExportService.ExportToExcel(dataTable, filePath, table);
                    return Ok(new { Message = "Datos exportados exitosamente", FilePath = filePath });
                }
                else
                {
                    return NotFound(new { Message = "No se encontraron datos para exportar" });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(500, new { Message = "Error: " + ex.Message });
            }
        }
    }
}
