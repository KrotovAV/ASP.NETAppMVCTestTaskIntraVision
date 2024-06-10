using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using DataBaseLayer.Entities.Base;
using DataBaseLayer.Entities.Enums;

namespace DataBaseLayer.Entities
{
    public class Order : Entity
    {
        //public int Id { get; set; }
        public DateTime DateTime { get; set; }
        public OrderType ActType { get; set; }
        public virtual List<OrderDetail> OrdersDetails { get; set; } = new List<OrderDetail>();
    }

    //public class Item : Entity
    //{
    //    //public int Id { get; set; }
    //    public ItemType ItemType { get; set; }
    //    public int? BrandId { get; set; }// внешний ключ
    //    public virtual Brand? Brand { get; set; } //навигационное свойство
    //    public string? Title { get; set; }
    //    public string? ImageUrl { get; set; }
    //    public decimal Price { get; set; }
    //    public int Count { get; set; }
    //}

    //public class Brand : Entity
    //{
    //    //public int Id { get; set; }
    //    public string? BrandName { get; set; }
    //    public virtual List<Item> ProductsItems { get; set; } = new List<Item>();
    //}
    //public class OrderDetail : Entity
    //{
    //    //public int Id { get; set; }
    //    public ItemType ItemType { get; set; }
    //    public int OrderId { get; set; } // внешний ключ
    //    public virtual Order? Order { get; set; } //навигационное свойство
    //    public int ItemId { get; set; }
    //    public int ItemCount { get; set; }
    //    public decimal ItemPrice { get; set; }
    //    public int ItemChange { get; set; }

    //}
}
