using ProductManager.Models.DbModels;
using ProductManager.Models.DTO;
using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Models.Mapper
{
	public static class MapperConfig
	{
		public static void Initialize()
		{

			AutoMapper.Mapper.Initialize(cfg => {
				cfg.CreateMap<Product, FullProductDTO>();
				cfg.CreateMap<Product, ProductBaseDTO>();
				cfg.CreateMap<Product, UpdateProductDTO>();

				cfg.CreateMap<FullProductDTO,Product>();
				cfg.CreateMap<ProductBaseDTO,Product>();
				cfg.CreateMap<UpdateProductDTO, Product>();
			});
		}
	}
}
