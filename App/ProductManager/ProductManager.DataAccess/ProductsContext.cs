using JetBrains.Annotations;
using Microsoft.EntityFrameworkCore;
using ProductManager.Models.DbModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ProductManager.DataAccess
{
	public class ProductsContext : DbContext
	{
		protected ProductsContext()
		{
		}

		public ProductsContext(DbContextOptions options) : base(options)
		{
		}

		public DbSet<Product> Products { get; set; }


		protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
		{
			base.OnConfiguring(optionsBuilder);
			//optionsBuilder.UseSqlite("Filename=./products.db");
		}

		protected override void OnModelCreating(ModelBuilder modelBuilder)
		{
			var date = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc);
			modelBuilder.Entity<Product>().HasData(
					new Product() { Id = 1, Code = Guid.NewGuid().ToString(), Name = "Cheese", Price = 20.5m , Created = date, LastUpdated = date },
					new Product() { Id = 2, Code = Guid.NewGuid().ToString(), Name = "Chicken", Price = 110.5m, Created = date, LastUpdated = date },
					new Product() { Id = 3, Code = Guid.NewGuid().ToString(), Name = "Apples", Price = 25.5m, Created = date, LastUpdated = date }
				);
		}

		public override int SaveChanges()
		{
			return base.SaveChanges();
		}

		public Func<DateTime> TimestampProvider { get; set; } = () => DateTime.UtcNow;

		private void TrackChanges()
		{
			foreach (var entry in this.ChangeTracker.Entries().Where(e => e.Entity is DateTrackedEntity && (e.State == EntityState.Added || e.State == EntityState.Modified)))
			{
				var auditable = entry.Entity as DateTrackedEntity;
				if (entry.State == EntityState.Added)
				{
					auditable.Created = TimestampProvider();
					auditable.LastUpdated = TimestampProvider();
				}
				else
				{
					auditable.LastUpdated = TimestampProvider();
				}
			}
		}
	}
}
