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
                    new Brand { Id=3, BrandName="Coca-Cola"},
                    new Brand { Id=4, BrandName="Schweppes"},
                    new Brand { Id=5, BrandName="Sprite"}
                }
            );

            modelBuilder.Entity<Item>().HasData(
                new Item[] {
                    new Item { Id=1, Title="1 рубль", Price=1, Count=20, ItemType = ItemType.coin, ImageUrl="/img/1.jpg"},
                    new Item { Id=2, Title="2 рубля", Price=2, Count=20, ItemType = ItemType.coin, ImageUrl="/img/2.jpg"},
                    new Item { Id=3, Title="5 рублей", Price=5, Count=20, ItemType = ItemType.coin, ImageUrl="/img/5.jpg"},
                    new Item { Id=4, Title="10 рублей", Price=10, Count=20, ItemType = ItemType.coin, ImageUrl="/img/10.jpg"},


                    new Item { Id=5, Title="Coca-Cola 0.33", BrandId=3, Price=20, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-cola03.jpg"},
                    new Item { Id=6, Title="Coca-Cola 0.5", BrandId=3, Price=25, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-cola05.jpg"},
                    new Item { Id=7, Title="Coca-Cola 1.0", BrandId=3, Price=35, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-cola10.jpg"},

                    new Item { Id=8, Title="Coca-Cola Лимон 0.33", BrandId=3, Price=20, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-colaLimon03.jpg"},
                    new Item { Id=9, Title="Coca-Cola Лимон 0.5", BrandId=3, Price=25, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-colaLimon05.jpg"},
                    new Item { Id=10, Title="Coca-Cola Лимон 1.0", BrandId=3, Price=35, Count=20, ItemType = ItemType.product, ImageUrl="/img/coca-colaLimon10.jpg"},

                    new Item { Id=11, Title="Fanta Апельсин 0.33", BrandId=1, Price=21, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaApelsin03.jpg"},
                    new Item { Id=12, Title="Fanta Апельсин 0.5", BrandId=1, Price=26, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaApelsin05.jpg"},
                    new Item { Id=13, Title="Fanta Апельсин 1.0", BrandId=1, Price=34, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaApelsin10.jpg"},

                    new Item { Id=14, Title="Fanta Виноград 0.33", BrandId=1, Price=22, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaVinograd03.jpg"},
                    new Item { Id=15, Title="Fanta Виноград 0.5", BrandId=1, Price=26, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaVinograd05.jpg"},
                    new Item { Id=16, Title="Fanta Виноград 1.0", BrandId=1, Price=36, Count=20, ItemType = ItemType.product, ImageUrl="/img/fantaVinograd10.jpg"},

                    new Item { Id=17, Title="Pepsi 0.33", Price=20, BrandId=2, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsi03.jpg"},
                    new Item { Id=18, Title="Pepsi 0.5", Price=25, BrandId=2, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsi05.jpg"},
                    new Item { Id=19, Title="Pepsi 1.0", Price=35, BrandId=2, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsi10.jpg"},

                    new Item { Id=20, Title="Pepsi Zero 0.33", BrandId=2, Price=24, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsiZero03.jpg"},
                    new Item { Id=21, Title="Pepsi Zero 0.5", BrandId=2, Price=29, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsiZero05.jpg"},
                    new Item { Id=22, Title="Pepsi Zero 1.0", BrandId=2, Price=48, Count=20, ItemType = ItemType.product, ImageUrl="/img/pepsiZero10.jpg"},

                    new Item { Id=23, Title="Schweppes Клюква 0.33", BrandId=4, Price=22, Count=22, ItemType = ItemType.product, ImageUrl="/img/schweppesKlukva03.jpg"},
                    new Item { Id=24, Title="Schweppes Клюква 0.5",BrandId=4,  Price=26, Count=20, ItemType = ItemType.product, ImageUrl="/img/schweppesKlukva05.jpg"},
                    new Item { Id=25, Title="Schweppes Клюква 1.0",BrandId=4,  Price=38, Count=20, ItemType = ItemType.product, ImageUrl="/img/schweppesKlukva10.jpg"},

                    new Item { Id=26, Title="Schweppes Лимон 0.33",BrandId=4,  Price=22, Count=22, ItemType = ItemType.product, ImageUrl="/img/schweppesLimon03.jpg"},
                    new Item { Id=27, Title="Schweppes Лимон 0.5",BrandId=4,  Price=27, Count=20, ItemType = ItemType.product, ImageUrl="/img/schweppesLimon05.jpg"},
                    new Item { Id=28, Title="Schweppes Лимон 1.0",BrandId=4,  Price=39, Count=20, ItemType = ItemType.product, ImageUrl="/img/schweppesLimon10.jpg"},

                    new Item { Id=29, Title="Sprite 0.33",BrandId=5,  Price=20, Count=20, ItemType = ItemType.product, ImageUrl="/img/sprite03.jpg"},
                    new Item { Id=30, Title="Sprite 0.5",BrandId=5,  Price=28, Count=20, ItemType = ItemType.product, ImageUrl="/img/sprite05.jpg"},
                    new Item { Id=31, Title="Sprite 1.0",BrandId=5,  Price=38, Count=20, ItemType = ItemType.product, ImageUrl="/img/sprite10.jpg"}

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
