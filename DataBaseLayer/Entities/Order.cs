using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer.Entities.Enums;

namespace DataBaseLayer.Entities
{
    public class Order
    {
        public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public OrderType ActType { get; set; }
        public virtual List<OrderDetail> OrdersDetails { get; set; } = new List<OrderDetail>();
    }

    public class Item //таблица физически ограничено: 8 ячеек для товаров и 4 для номинала монет
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public required string Title { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
    #region
    //public class Coin : Item
    //{
    //    //public int Id { get; set; }
        //public ItemType ItemType { get; set; }
        //public required string Title { get; set; }
        //public string? ImageUrl { get; set; }
        //public decimal Price { get; set; }
        //public int Count { get; set; }
    //}
    //public class Product : Item
    //{
        //public int Id { get; set; }
        //public ItemType ItemType { get; set; }
        //public int ProductNameId { get; set; } //внешний ключ
        //public virtual ProductName? ProductName { get; set; }//навигационное свойство
        //public string? Title { get; set; } // берём по внешнему ключу
        //public string? ImageUrl { get; set; } // берём по внешнему ключу
        //public decimal Price { get; set; }
        //public int Count { get; set; }
    //}
#endregion
    public class ProductName
    {
        public int Id { get; set; }
        public required string Name { get; set; }
        public string? ImageUrl { get; set; }
    }
    public class OrderDetail
    {
        public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public int OrderId { get; set; } // внешний ключ
        public virtual Order? Order { get; set; } //навигационное свойство
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemChange { get; set; }

    }
}
