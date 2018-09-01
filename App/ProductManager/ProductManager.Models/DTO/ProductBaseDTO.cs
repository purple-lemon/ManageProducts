using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Models.DTO
{
	public class ProductBaseDTO
	{
		public string Code { get; set; }
		public string Name { get; set; }
		public string PhotoUrl { get; set; }
		public decimal Price { get; set; }
	}
}
