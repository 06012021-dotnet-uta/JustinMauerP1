using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsStore.Controllers
{
    public class Item : Controller
    {

        private readonly IApp _appStore;

        // create a constructor that will inject the business layer
        public Item(IApp appStore)
        {
            this._appStore = appStore;
        }

        // GET: Item
        public async Task<ActionResult> Index()
        {
            List<Store> storeList = await _appStore.StoreListAsync();
            
            return View("StoreList", storeList);
        }

        
        public async Task<ActionResult> StoreInv(int storeId)
        {
            List<ModelsLibrary.Item> itemList = await _appStore.StoreItemListAsync(storeId);

            return View("ItemList", itemList);
        }

        public async Task<ActionResult> StoreInventory(Store store)
        {
            List<ModelsLibrary.Item> itemList = await _appStore.StoreItemListAsync(store.StoreId);

            return View("ItemList", itemList);
        }

        // GET: Item/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Item/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: Item/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Item/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: Item/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Item/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
