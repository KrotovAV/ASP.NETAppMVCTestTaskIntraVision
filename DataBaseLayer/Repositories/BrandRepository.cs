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
    public class BrandRepository : DbRepository<Brand>
    {
        public BrandRepository(VendingAppContext db) : base(db) { }
        public override IQueryable<Brand> Items => base.Items;

    }
}
