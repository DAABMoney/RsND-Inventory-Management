using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsND_Inventory_Management.Data;
using RsND_Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Contracts
{
    [Authorize(Roles ="Administrator, Client")]
    public class CustomerController : Controller
    {
        private readonly ICustomerRepo _repo;
        private readonly IMapper _mapper;

        public CustomerController(ICustomerRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: CustomerController
        public ActionResult Index()
        {
            var customers = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Customer>, List<CustomerVM>>(customers);
            return View(model);
        }

        // GET: CustomerController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var customer = _repo.FindById(id);
            var cust = _mapper.Map<CustomerVM>(customer);
            return View(cust);
        }

        // GET: CustomerController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: CustomerController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(CustomerVM cust)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cust);
                }
                var customer = _mapper.Map<Customer>(cust);
                customer.Registered = DateTime.Now;
                var isSuccess = _repo.Create(customer);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(cust);
                }
                return RedirectToAction(nameof(Index));
            }
            catch

            { 
            ModelState.AddModelError("", "Check for Information");
            return View();
            }
        }

        // GET: CustomerController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var customer = _repo.FindById(id);
            var cust = _mapper.Map<CustomerVM>(customer);
            return View(cust);
        }

        // POST: CustomerController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(CustomerVM cust)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(cust);
                }
                var customer = _mapper.Map<Customer>(cust);
                var isSuccess = _repo.Update(customer);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(cust);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(cust);
            }
        }

        // GET: CustomerController/Delete/5
        public ActionResult Delete(int id)
        {
            var customer = _repo.FindById(id);
            if (customer == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(customer);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: CustomerController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, CustomerVM cust)
        {
            try
            {
                var customer = _repo.FindById(id);
                if(customer == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(customer);
                if (!isSuccess)
                {

                    return View(cust);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
