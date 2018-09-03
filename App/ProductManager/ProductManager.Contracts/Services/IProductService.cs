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
		FullProductDTO Update(UpdateProductDTO model);
		IEnumerable<FullProductDTO> Get();
		FullProductDTO Get(int id);
		bool VerifyCode(string code);
		bool VerifyCode(string code, int id);
	}
}
