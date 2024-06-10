using DataBaseLayer.Context;
using DataBaseLayer.Entities.Enums;
using DataBaseLayer.Repositories;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using PresentationLayer.ViewModels;
using System;

namespace VendingMachineWebApplication.Controllers
{
    public class ProductsController : Controller
    {
        //private VendingAppContext _context;
        private ItemRepository _itemRepo;
        public ProductsController(
            //VendingAppContext context,
            ItemRepository itemRepo
            )
        {
            //_context = context;
            _itemRepo = itemRepo;
        }


        public async Task<IActionResult> ShowAllProducts()
        {
            //var products = await _context.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
            //var products = await _itemRepo.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();

            AllProductsViewModel obj = new AllProductsViewModel();
            obj.allProducts = await _itemRepo.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
            obj.totalChoose = 30;
            obj.title = "Газированные напитки";
            return View(obj);
            //return View(products);
        }
        public async Task<IActionResult> ShowOrderProducts()
        {
            //var products = await _context.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
            var orderProducts = await _itemRepo.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
            return View(orderProducts);
        }
        public async Task<IActionResult> ShowOrderCoins()
        {
            //var products = await _context.Items.Where(x => x.ItemType == ItemType.product).ToListAsync();
            var orderCoins = await _itemRepo.Items.Where(x => x.ItemType == ItemType.coin).ToListAsync();
            return View(orderCoins);
        }

    }
}
