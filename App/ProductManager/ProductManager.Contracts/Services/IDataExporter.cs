using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Contracts.Services
{
	public interface IDataExporter
	{
		byte[] GetProductsExcelBytes();
	}
}
