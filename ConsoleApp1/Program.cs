using Microsoft.EntityFrameworkCore;

namespace ConsoleApp1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            const string connection = "Server=DESKTOP-IFVARIJ\\SQLEXPRESS;Database=PhoneCompanyDB;User Id=Admin;Password=MsSQLavk;TrustServerCertificate=True";
            //using var db = new AppContext(new DbContextOptionsBuilder<AppContext>().UseSqlServer(connection).Options);


        }
    }
}