using ProductManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Contracts.Services
{
	public interface IProductService
	{
		FullProductDTO Add(ProductBaseDTO model);
		void Delete(int id);
		FullProductDTO Update(ProductBaseDTO model);
		FullProductDTO Get();
		FullProductDTO Get(int id);
	}
}
