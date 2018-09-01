using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ProductManager.Models.DbModels
{
	public class Product : DateTrackedEntity
	{
		[Key]
		public int Id { get; set; }
		public string Code { get; set; }
		public string Name { get; set; }
		public string PhotoUrl { get; set; }
		public decimal Price { get; set; }
	}
}
