using OfficeOpenXml;
using OfficeOpenXml.Style;
using ProductManager.Contracts.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManager.Services
{
	public class DataExporter : IDataExporter
	{
		public IProductService Service;
		public DataExporter(IProductService service)
		{
			Service = service;
		}
		public ExcelPackage GetPackage()
		{
			var products = Service.Get();
			var package = new ExcelPackage();

			var worksheet = package.Workbook.Worksheets.Add("Products");
			Action<int,string> addHeader = (int index, string text) =>
			{
				worksheet.Cells[1, index].Value = text;
				worksheet.Cells[1, index].Style.Font.Size = 12;
				worksheet.Cells[1, index].Style.Font.Bold = true;

				worksheet.Cells[1, index].Style.Border.Top.Style = ExcelBorderStyle.Hair;
			};
			addHeader(1, "Id");
			addHeader(2, "Code");
			addHeader(3, "Name");
			addHeader(4, "Price");

			for (var i = 0; i<products.Count(); i++)
			{
				var row = i + 2;
				var p = products.ElementAt(i);
				worksheet.Cells[row, 1].Value = p.Id;
				worksheet.Cells[row,2].Value = p.Code;
				worksheet.Cells[row, 3].Value = p.Name;
				worksheet.Cells[row, 4].Value = p.Price;

			}
			return package;
		}
		public byte[] GetProductsExcelBytes()
		{
			var p = GetPackage();
			var result = p.GetAsByteArray();
			p.Dispose();
			return result;
		}
	}
}
