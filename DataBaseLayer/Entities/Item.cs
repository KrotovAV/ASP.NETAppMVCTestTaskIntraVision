using DataBaseLayer.Entities.Base;
using DataBaseLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class Item : Entity
    {
        //public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public int? BrandId { get; set; }// внешний ключ
        public virtual Brand? Brand { get; set; } //навигационное свойство
        public string? Title { get; set; }
        public string? ImageUrl { get; set; }
        public decimal Price { get; set; }
        public int Count { get; set; }
    }
}
