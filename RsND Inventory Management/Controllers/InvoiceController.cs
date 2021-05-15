using AutoMapper;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using RsND_Inventory_Management.Models;
using RsND_Inventory_Management.Repo;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Controllers
{
    public class InvoiceController : Controller
    {
        private readonly IInvoiceRepo _repo;
        private readonly IMapper _mapper;

        public InvoiceController(IInvoiceRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: InvoiceController
        public ActionResult Index()
            {
            var invoices = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Invoice>, List<InvoiceVM>>(invoices);
            return View(model);
        }

        // GET: InvoiceController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var invoice = _repo.FindById(id);
            var inv = _mapper.Map<InvoiceVM>(invoice);
            return View(inv);
        }

        // GET: InvoiceController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: InvoiceController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(InvoiceVM inv)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inv);
                }
                var invoice = _mapper.Map<Invoice>(inv);
                invoice.Date = DateTime.Now;
                var isSuccess = _repo.Create(invoice);
                if(!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(inv);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View();
            }
        }

        // GET: InvoiceController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var invoice = _repo.FindById(id);
            var inv = _mapper.Map<InvoiceVM>(invoice);
            return View(inv);
        }

        // POST: InvoiceController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(InvoiceVM inv)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(inv);
                }
                var invoice = _mapper.Map<Invoice>(inv);
                var isSuccess = _repo.Update(invoice);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(inv);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(inv);
            }
        }

        // GET: InvoiceController/Delete/5
        public ActionResult Delete(int id)
        {
            var invoice = _repo.FindById(id);
            if (invoice == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(invoice);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: InvoiceController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, InvoiceVM inv)
        {
            try
            {
                var invoice = _repo.FindById(id);
                if (invoice == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(invoice);
                if (!isSuccess)
                {

                    return View(inv);
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
