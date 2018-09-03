using AutoMapper;
using Microsoft.EntityFrameworkCore;
using ProductManager.Contracts.Services;
using ProductManager.DataAccess;
using ProductManager.Models.DbModels;
using ProductManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Linq;

namespace ProductManager.Services
{
	public class ProductService : IProductService
	{
		public ProductsContext context { get; set; }
		public ProductService(ProductsContext context)
		{
			this.context = context;
		}
		public FullProductDTO Add(ProductBaseDTO model)
		{
			var dbItem = Mapper.Map<Product>(model);
			context.Add(dbItem);
			context.SaveChanges();
			return Mapper.Map<FullProductDTO>(dbItem);
		}

		public void Delete(int id)
		{
			var product = new Product() { Id = id };
			context.Entry(product).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
			context.SaveChanges();
		}

		public IEnumerable<FullProductDTO> Get()
		{
			var result = context.Products.AsNoTracking();
			return Mapper.Map<List<FullProductDTO>>(result);
		}

		public FullProductDTO Get(int id)
		{
			var result = context.Products.AsNoTracking().FirstOrDefault();
			return Mapper.Map<FullProductDTO>(result);
		}

		public FullProductDTO Update(UpdateProductDTO model)
		{
			var mappedProduct = Mapper.Map<Product>(model);
			context.Entry(mappedProduct).State = EntityState.Modified;
			context.SaveChanges();
			return Mapper.Map<FullProductDTO>(mappedProduct);
		}

		public bool VerifyCode(string code)
		{
			return context.Products.AsNoTracking().FirstOrDefault(x => x.Code.ToLower() == code.ToLower()) == null;
		}

		public bool VerifyCode(string code, int id)
		{
			return context.Products.AsNoTracking().FirstOrDefault(x => x.Code.ToLower() == code.ToLower() && x.Id != id) == null;
		}
	}
}
