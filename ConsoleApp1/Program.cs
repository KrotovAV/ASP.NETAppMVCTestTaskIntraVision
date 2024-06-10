using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using DataBaseLayer.Repositories;
using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string connection = "Server=DESKTOP-IFVARIJ\\SQLEXPRESS;Database=VendingMachineDB;User Id=Admin;Password=MsSQLavk;TrustServerCertificate=True";
            using var db = new VendingAppContext(new DbContextOptionsBuilder<VendingAppContext>().UseSqlServer(connection).Options);

             var prods = db.Brands.Take(5).ToList();
            if (prods != null)
            {
                Console.WriteLine($"есть : {prods.Count()} шт");

                foreach (var pro in prods)
                {
                    Console.WriteLine(pro.BrandName);

                }
            }
            //-------------------------
            BrandRepository brandRepo = new BrandRepository(db);
            var brandsR = brandRepo.Items.ToList();
            foreach (var brand in brandsR)
            {
                Console.WriteLine(brand.BrandName);

            }
            //-----------------------------
            ItemRepository itemRepo = new ItemRepository(db);
            var itemsR = itemRepo.Items.ToList();
            foreach (var item in itemsR)
            {
                Console.WriteLine(item.Title);
            }

            //--------------------------------
            OrderRepository orderRepo = new OrderRepository(db);
            var ordersR = orderRepo.Items.ToList();
            foreach (var order in ordersR)
            {
                Console.WriteLine(order.DateTime);
            }
            //---------------------
            OrderDetailRepository orderDetailRepo = new OrderDetailRepository(db);
            var ordersDetailR = orderDetailRepo.Items.ToList();
            foreach (var orderDetail in ordersDetailR)
            {
                Console.WriteLine(orderDetail.ItemCount + " - " + orderDetail.ItemPrice);
            }
            //---------------------



            Console.WriteLine("End");
        }
    }
}