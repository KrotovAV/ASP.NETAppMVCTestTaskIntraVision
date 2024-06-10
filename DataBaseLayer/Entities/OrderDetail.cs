using DataBaseLayer.Entities.Base;
using DataBaseLayer.Entities.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class OrderDetail : Entity
    {
        //public int Id { get; set; }
        public ItemType ItemType { get; set; }
        public int OrderId { get; set; } // внешний ключ
        public virtual Order? Order { get; set; } //навигационное свойство
        public int ItemId { get; set; }
        public int ItemCount { get; set; }
        public decimal ItemPrice { get; set; }
        public int ItemChange { get; set; }

    }
}
