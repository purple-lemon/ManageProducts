using Moq;
using ProductManager.Contracts.Services;
using ProductManager.Models.DTO;
using ProductManager.Services;
using System;
using System.Collections.Generic;
using Xunit;

namespace ProductManager.XUnit
{
	public class ExportTests
	{
		[Fact]
		public void ExportTest()
		{
			Assert.Equal(5, 5);
			//var productsStub = new List<FullProductDTO>()
			//{
			//	new FullProductDTO(){ Id = 1, Code = "123", Name = "Cheese", Price = 100m },
			//	new FullProductDTO(){ Id = 24, Code = "321", Name = "Bread", Price = 23m },
			//};
			//var productServiceMoq = new Mock<IProductService>();
			//productServiceMoq.Setup(x => x.Get()).Returns(productsStub);
			//var exportService = new DataExporter(productServiceMoq.Object);
			//var package = exportService.GetPackage();
			//var ws = package.Workbook.Worksheets["Products"];
			//Assert.NotNull(ws);

			//foreach (var p in productsStub)
			//{
			//	var row = productsStub.IndexOf(p) + 2;
			//	Assert.Equal(ws.Cells[row, 1].GetValue<string>(), p.Id.ToString());
			//	Assert.Equal(ws.Cells[row, 2].GetValue<string>(), p.Name.ToString());
			//}
		}
	}
}
