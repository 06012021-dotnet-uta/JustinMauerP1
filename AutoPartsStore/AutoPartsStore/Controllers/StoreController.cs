//using AutoPartsStore.Models;
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
                Console.WriteLine("In: " + register);
                ViewBag.Welcome = "Welcoming Example With ViewBag";
                return View("LoggedInLandingPage");
            }
            else
            {
                Console.WriteLine("Out: " + register);
                ViewBag.ErrorText = "Welcome Example With Error";
                return View("VerifyCreateCustomer");
            }

        }

        public async Task<ActionResult> CustomerList()
        {
            List<Customer> customerList = await _appStore.CustomerListAsync();

            return View(customerList);

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
