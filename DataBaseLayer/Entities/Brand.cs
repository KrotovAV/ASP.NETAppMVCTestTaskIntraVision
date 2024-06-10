using DataBaseLayer.Entities.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Entities
{
    public class Brand : Entity
    {
        //public int Id { get; set; }
        public string? BrandName { get; set; }
        public virtual List<Item> ProductsItems { get; set; } = new List<Item>();
    }
}
