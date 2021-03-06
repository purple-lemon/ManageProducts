﻿// <auto-generated />
using System;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.EntityFrameworkCore.Storage.ValueConversion;
using ProductManager.DataAccess;

namespace ProductManager.DataAccess.Migrations
{
    [DbContext(typeof(ProductsContext))]
    partial class ProductsContextModelSnapshot : ModelSnapshot
    {
        protected override void BuildModel(ModelBuilder modelBuilder)
        {
#pragma warning disable 612, 618
            modelBuilder
                .HasAnnotation("ProductVersion", "2.1.2-rtm-30932");

            modelBuilder.Entity("ProductManager.Models.DbModels.Product", b =>
                {
                    b.Property<int>("Id")
                        .ValueGeneratedOnAdd();

                    b.Property<string>("Code");

                    b.Property<DateTime>("Created");

                    b.Property<DateTime>("LastUpdated");

                    b.Property<string>("Name");

                    b.Property<string>("PhotoUrl");

                    b.Property<decimal>("Price");

                    b.HasKey("Id");

                    b.ToTable("Products");

                    b.HasData(
                        new { Id = 1, Code = "6e2fd4ce-9718-453a-b621-538ee8408fc8", Created = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), LastUpdated = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), Name = "Cheese", Price = 20.5m },
                        new { Id = 2, Code = "dc385665-f436-4b2c-8afa-d940c9bca915", Created = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), LastUpdated = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), Name = "Chicken", Price = 110.5m },
                        new { Id = 3, Code = "d27b7b76-eeaa-4757-a0d9-43efc6250a6f", Created = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), LastUpdated = new DateTime(2018, 9, 1, 13, 43, 26, 819, DateTimeKind.Utc), Name = "Apples", Price = 25.5m }
                    );
                });
#pragma warning restore 612, 618
        }
    }
}
