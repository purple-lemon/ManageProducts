using Microsoft.AspNetCore.Mvc;
using OfficeOpenXml;
using OfficeOpenXml.Style;
using ProductManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ProductManager.Controllers
{
	[ApiVersion("1.0")]
	[Route("api/{version:apiVersion}/export")]
	public class ExportController : Controller
	{
		public IDataExporter Service { get; set; }
		public ExportController(IDataExporter service)
		{
			Service = service;
		}

		[HttpGet]
		public IActionResult Download()
		{
			byte[] fileContents;

			fileContents = Service.GetProductsExcelBytes();

			if (fileContents == null || fileContents.Length == 0)
			{
				return NotFound();
			}

			return File(
				fileContents: fileContents,
				contentType: "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet",
				fileDownloadName: "test.xlsx"
			);
		}
	}
}
