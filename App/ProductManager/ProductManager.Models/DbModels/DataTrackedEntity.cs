using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Models.DbModels
{
	public abstract class DataTrackedEntity
	{
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
