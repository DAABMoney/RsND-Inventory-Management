using AutoMapper;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RsND_Inventory_Management.Contracts;
using RsND_Inventory_Management.Data;
using RsND_Inventory_Management.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace RsND_Inventory_Management.Controllers
{
    [Authorize(Roles = "Administrator, Client")]
    public class SupplierController : Controller
    {
        private readonly ISupplierRepo _repo;
        private readonly IMapper _mapper;

        public SupplierController(ISupplierRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: SupplierController
        public ActionResult Index()
        {
            var suppliers = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Supplier>, List<SupplierVM>>(suppliers);
            return View(model);
        }

        // GET: SupplierController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var supplier = _repo.FindById(id);
            var sup = _mapper.Map<SupplierVM>(supplier);
            return View(sup);
        }

        // GET: SupplierController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: SupplierController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(SupplierVM sup)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sup);
                }
                var supplier = _mapper.Map<Supplier>(sup);
                var isSuccess = _repo.Create(supplier);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(sup);
                }
                return RedirectToAction(nameof(Index));
            }
            catch (Exception ex)
            {
                ModelState.AddModelError("", "Check for Information");
                return View();
            }
        }

        // GET: SupplierController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var supplier = _repo.FindById(id);
            var sup = _mapper.Map<SupplierVM>(supplier);
            return View(sup);
        }

        // POST: SupplierController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(SupplierVM sup)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sup);
                }
                var supplier = _mapper.Map<Supplier>(sup);
                var isSuccess = _repo.Update(supplier);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(sup);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(sup);
            }
        }

        // GET: SupplierController/Delete/5
        public ActionResult Delete(int id)
        {
            var supplier = _repo.FindById(id);
            if (supplier == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(supplier);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: SupplierController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, SupplierVM sup)
        {
            try
            {
                var supplier = _repo.FindById(id);
                if (supplier == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(supplier);
                if (!isSuccess)
                {

                    return View(sup);
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
