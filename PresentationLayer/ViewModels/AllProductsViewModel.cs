using DataBaseLayer.Entities.Enums;
using DataBaseLayer.Entities;
using DataBaseLayer.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PresentationLayer.ViewModels
{
    public class AllProductsViewModel
    {
        //private ItemRepository _itemRepo;
        //public AllProductsViewModel(
        //    //VendingAppContext context,
        //    ItemRepository itemRepo
        //    )
        //{
        //    //_context = context;
        //    _itemRepo = itemRepo;
        //}

        public IEnumerable<Item>? allProducts { get; set; }
            
            //= await _itemRepo.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
        public int totalChoose { get; set; }
        public string title { get; set; }
    }
}
