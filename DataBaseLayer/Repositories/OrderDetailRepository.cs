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
    public class OrderDetailRepository : DbRepository<OrderDetail>
    {
        public OrderDetailRepository(VendingAppContext db) : base(db) { }
        public override IQueryable<OrderDetail> Items => base.Items.Include(item => item.Order);

    }
}
