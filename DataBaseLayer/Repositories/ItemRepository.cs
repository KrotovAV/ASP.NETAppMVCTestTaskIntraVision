using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace DataBaseLayer.Repositories
{
    public class ItemRepository : DbRepository<Item>
    {
        public ItemRepository(VendingAppContext db) : base(db) { }
        public override IQueryable<Item> Items => base.Items;

    }
}
