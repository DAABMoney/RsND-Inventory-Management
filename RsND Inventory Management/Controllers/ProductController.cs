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
    public class ProductController : Controller
    {
        private readonly IProductRepo _repo;
        private readonly IMapper _mapper;

        public ProductController(IProductRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: ProductController
        public ActionResult Index()
        {
            var products = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Product>, List<ProductVM>>(products);
            return View(model);
        }

        // GET: ProductController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var product = _repo.FindById(id);
            var pro = _mapper.Map<ProductVM>(product);
            return View(pro);
        }

        // GET: ProductController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: ProductController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(ProductVM pro)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pro);
                }
                var product = _mapper.Map<Product>(pro);
                var isSuccess = _repo.Create(product);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(pro);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View();
            }
        }

        // GET: ProductController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var product = _repo.FindById(id);
            var pro = _mapper.Map<ProductVM>(product);
            return View(pro);
        }

        // POST: ProductController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(ProductVM pro)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(pro);
                }
                var product = _mapper.Map<Product>(pro);
                var isSuccess = _repo.Update(product);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(pro);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(pro);
            }
        }

        // GET: ProductController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = _repo.FindById(id);
            if (product == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(product);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: ProductController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, ProductVM pro)
        {
            
                try
                {
                    var product = _repo.FindById(id);
                    if (product == null)
                    {
                        return NotFound();
                    }
                    var isSuccess = _repo.Delete(product);
                    if (!isSuccess)
                    {

                        return View(pro);
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
