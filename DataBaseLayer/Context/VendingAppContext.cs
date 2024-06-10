using DataBaseLayer.Entities;
using DataBaseLayer.Entities.Enums;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace DataBaseLayer.Context
{
    public class VendingAppContext : DbContext
    {
        public DbSet<Brand> Brands { get; set; }
        public DbSet<Item> Items { get; set; }
        public DbSet<Order> Orders { get; set; }
        public DbSet<OrderDetail> OrdersDetails { get; set; }

        //    dotnet ef migrations add InitialMigration 
        //    dotnet ef database update
        public VendingAppContext()
        {
        }
        public VendingAppContext(DbContextOptions dbc) : base(dbc)
        {
        }
        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var config = new ConfigurationBuilder()
                    .AddJsonFile("appsettings.json")
                    .SetBasePath(Directory.GetCurrentDirectory())
                    .Build();

            optionsBuilder.
                    UseSqlServer(config.GetConnectionString("Connection"));
                    //optionsBuilder.UseInMemoryDatabase("INMemoryDB.db");
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Item>().HasOne(u => u.Brand).WithMany(c => c.ProductsItems).HasForeignKey(u => u.BrandId);
            modelBuilder.Entity<OrderDetail>().HasOne(u => u.Order).WithMany(c => c.OrdersDetails).HasForeignKey(u => u.OrderId);
  

            modelBuilder.Entity<Brand>().HasData(
                new Brand[]{
                    new Brand { Id=1, BrandName="Fanta"},
                    new Brand { Id=2, BrandName="Pepsi"},
                    new Brand { Id=3, BrandName="Cola"},
                    new Brand { Id=4, BrandName="Merinda"},
                    new Brand { Id=5, BrandName="Sprite"},
                    new Brand { Id=6, BrandName="Shweps"}
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item[] {
                    new Item { Id=1, Title="1 рубль", Price=1, Count=20, ItemType = ItemType.coin},
                    new Item { Id=2, Title="2 рубля", Price=2, Count=20, ItemType = ItemType.coin},
                    new Item { Id=3, Title="5 рублей", Price=5, Count=20, ItemType = ItemType.coin},
                    new Item { Id=4, Title="10 рублей", Price=10, Count=20, ItemType = ItemType.coin},

                    new Item { Id=5, Title="Fanta 0.33", Price=20, Count=20, ItemType = ItemType.product},
                    new Item { Id=6, Title="Fanta 0.5", Price=25, Count=20, ItemType = ItemType.product},
                    new Item { Id=7, Title="Pepsi 0.33", Price=22, Count=20, ItemType = ItemType.product},
                    new Item { Id=8, Title="Pepsi 0.35", Price=27, Count=20, ItemType = ItemType.product},
                    new Item { Id=9, Title="Cola 0.33", Price=25, Count=20, ItemType = ItemType.product},
                    new Item { Id=10, Title="Cola 0.5", Price=30, Count=20, ItemType = ItemType.product},
                    new Item { Id=11, Title="Merinda 0.33", Price=25, Count=20, ItemType = ItemType.product},
                    new Item { Id=12, Title="Merinda 0.5", Price=25, Count=20, ItemType = ItemType.product}
                }
            );

            modelBuilder.Entity<OrderDetail>().HasData(
               new OrderDetail[]
               {
                    new OrderDetail{Id = 1, ItemType = ItemType.coin, OrderId=1, ItemId=1, ItemPrice = 1, ItemCount=10, ItemChange=+10},
                    new OrderDetail{Id = 2, ItemType = ItemType.coin, OrderId=1, ItemId=4, ItemPrice = 10, ItemCount=1, ItemChange=+1},
                    new OrderDetail{Id = 3, ItemType = ItemType.product, OrderId=1, ItemId=5, ItemPrice = 20, ItemCount=1, ItemChange=-1},
                    new OrderDetail{Id = 4, ItemType = ItemType.coin, OrderId=2, ItemId=1, ItemPrice = 1, ItemCount=10, ItemChange=+10},
                    new OrderDetail{Id = 5, ItemType = ItemType.coin, OrderId=2, ItemId=4, ItemPrice = 10, ItemCount=3, ItemChange=+3},
                    new OrderDetail{Id = 6, ItemType = ItemType.product, OrderId=2, ItemId=5, ItemPrice = 20, ItemCount=2, ItemChange=-2}
               }
            );

            modelBuilder.Entity<Order>().HasData(
                new Order[]
                {
                     new Order {Id=1, DateTime = new DateTime(2024, 6, 08, 10, 0, 0), ActType=OrderType.sale
                     //,
                     //    OrdersDetails = new List<OrderDetail>{
                     //        new OrderDetail{Id = 1, ItemType = ItemType.coin, OrderId=1, ItemId=1, ItemPrice = 1, ItemCount=10, ItemChange=+10},
                     //        new OrderDetail{Id = 2, ItemType = ItemType.coin, OrderId=1, ItemId=4, ItemPrice = 10, ItemCount=1, ItemChange=+1},
                     //        new OrderDetail{Id = 3, ItemType = ItemType.product, OrderId=1, ItemId=5, ItemPrice = 20, ItemCount=1, ItemChange=-1}
                     //    }
                     },

                     new Order {Id=2, DateTime = new DateTime(2024, 6, 09, 10, 0, 0), ActType=OrderType.sale
                     //,
                     //OrdersDetails = new List<OrderDetail>{
                     //        new OrderDetail{Id = 4, ItemType = ItemType.coin, OrderId=2, ItemId=1, ItemPrice = 1, ItemCount=10, ItemChange=+10},
                     //        new OrderDetail{Id = 5, ItemType = ItemType.coin, OrderId=2, ItemId=4, ItemPrice = 10, ItemCount=3, ItemChange=+3},
                     //        new OrderDetail{Id = 6, ItemType = ItemType.product, OrderId=2, ItemId=5, ItemPrice = 20, ItemCount=2, ItemChange=-2}
                     //    }
                     }
                }
            );
        }
    }
}
