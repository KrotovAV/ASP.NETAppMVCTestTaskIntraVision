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
        public DbSet<ProductName> ProductsNames { get; set; }
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
            //modelBuilder.Entity<Phone>().HasOne(u => u.Abonent).WithMany(c => c.Phones).HasForeignKey(u => u.AbonentId).
            modelBuilder.Entity<OrderDetail>().HasOne(u => u.Order).WithMany(c => c.OrdersDetails).HasForeignKey(u => u.OrderId);
  

            modelBuilder.Entity<ProductName>().HasData(
                new ProductName[]{
                    new  ProductName { Id=1, Name="Fanta 0.33", ImageUrl="Fanta_33"},
                    new  ProductName { Id=2, Name="Fanta 0.5",  ImageUrl="Fanta_5"},
                    new  ProductName { Id=3, Name="Pepsi 0.33", ImageUrl="Pepsi_33"},
                    new  ProductName { Id=4, Name="Pepsi 0.5",  ImageUrl="Pepsi_5"},
                    new  ProductName { Id=5, Name="Cola 0.33", ImageUrl="Cola_33"},
                    new  ProductName { Id=6, Name="Cola 0.5",  ImageUrl="Cola_5"},
                    new  ProductName { Id=7, Name="Merinda 0.33", ImageUrl="Merinda_33"},
                    new  ProductName { Id=8, Name="Merinda 0.5",  ImageUrl="Merinda_5"},
                    new  ProductName { Id=9, Name="Sprite 0.33", ImageUrl="Sprite_33"},
                    new  ProductName { Id=10, Name="Sprite 0.5",  ImageUrl="Sprite_5"},
                    new  ProductName { Id=11, Name="Shweps 0.33", ImageUrl="Shweps_33"},
                    new  ProductName { Id=12, Name="Shweps 0.5",  ImageUrl="Shweps_5"}
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
