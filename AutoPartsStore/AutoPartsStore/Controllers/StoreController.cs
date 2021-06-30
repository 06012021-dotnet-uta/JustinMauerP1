//using AutoPartsStore.Models;
using BusinessLayer;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore.Metadata.Internal;
using ModelsLibrary;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace AutoPartsStore.Controllers
{
    public class StoreController : Controller
    {

        private readonly IApp _appStore;
        
        // create a constructor that will inject the business layer
        public StoreController(IApp appStore)
        {
            this._appStore = appStore;
        }

        // GET: Store
        public ActionResult Index()
        {
           // Customer cust = new Customer();
           /* {
                firstName = "John",
                lastName = "Smith",
                email = "jsmith@email.com"
            };*/
            return View();
        }

        // GET: Store/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: Store/Create
        public ActionResult Create()
        {
            return View("CreateCustomer");
        }

        [HttpPost]
        public ActionResult CreateCustomer(Customer c)
        {
            if(!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }
            return View("VerifyCreateCustomer", c);
        }

        [HttpPost]
        public async Task<ActionResult> CreateNewCustomer(Customer c)
        {
            if(!ModelState.IsValid)
            {
                RedirectToAction("Create");
            }

            bool register = await _appStore.RegisterCustomerAsync(c);
            
            if(register)
            {
                ViewBag.Welcome = "Welcoming Example With ViewBag";
                return View("Index");
            }
            else
            {
                ViewBag.ErrorText = "Welcome Example With Error";
                return View("VerifyCreateCustomer");
            }

        }

        /*[HttpPost]
        public async Task<ActionResult> Select(Tuple<Store,Customer> tuple)
        {
            // display parts for store selected
           List<ModelsLibrary.Item> itemList = await _appStore.ItemListAsync(tuple.Item1);

            // change store for customer object
            bool changeStore = await _appStore.ChangeStore(tuple.Item1, tuple.Item2);

            if(changeStore)
            {
                return View("VerifyCreateCustomer", tuple.Item2);
            }
            else
            {
                return await Login(tuple.Item2.LastName, tuple.Item2.Password);
            }

            return View();
        }*/

        [HttpPost]
        public async Task<ActionResult> Select(int store)
        {

            Customer cust = new Customer();
            // display parts for store selected
            List<ModelsLibrary.Item> itemList = await _appStore.ItemListAsync(store);

            // change store for customer object
            bool changeStore = await _appStore.ChangeStore(store, cust);

            if (changeStore)
            {
                return View("VerifyCreateCustomer", cust);
            }
            else
            {
                return await Login(cust.LastName, cust.Password);
            }

            return View();
        }

        // POST: Store/Create
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

        [HttpPost]
        public async Task<ActionResult> Login(string LastName, string Password)
        {

            Customer cust = await _appStore.FindCustomerAsync(LastName, Password);
            if(cust == null)
            {
                return View("../Home/Index");
            }
            else
            {
                // get list of stores
                List<Store> storeList = await _appStore.StoreListAsync();

                // return a view to allow customer to select store to shop from
                var tuple = new Tuple<List<Store>, Customer>(storeList, cust);

                   return View("CustomerLoggedIn", tuple);
            }
            /*
            return View();*/
        }

        // GET: Store/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: Store/Edit/5
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

        // GET: Store/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: Store/Delete/5
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
