using DataBaseLayer.Context;
using DataBaseLayer.Entities;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Numerics;
using System.Text;
using System.Threading.Tasks;

namespace DataBaseLayer.Repositories
{
    public class OrderRepository : DbRepository<Order>
    {
        public OrderRepository(VendingAppContext db) : base(db) { }
        //public override IQueryable<Order> Items => base.Items.Include("OrdersDetails");
        public override IQueryable<Order> Items => base.Items.Include(item => item.OrdersDetails);

    }
}
