using System;
using System.Collections.Generic;
using System.Text;

namespace ProductManager.Models.DbModels
{
	public abstract class DateTrackedEntity
	{
		public DateTime Created { get; set; }
		public DateTime LastUpdated { get; set; }
	}
}
