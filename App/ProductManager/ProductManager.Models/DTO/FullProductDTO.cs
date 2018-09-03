using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Models.DTO
{
	public class FullProductDTO : ProductBaseDTO
	{
		public int Id { get; set; }
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
