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
    public class OrderController : Controller
    {
        private readonly IOrderRepo _repo;
        private readonly IMapper _mapper;

        public OrderController(IOrderRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: OrderController
        public ActionResult Index()
        {
            var Orders = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Order>, List<OrderVM>>(Orders);
            return View(model);
        }

        // GET: OrderController/Details/5
        public ActionResult Details(int id)
        {

            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var order = _repo.FindById(id);
            var ord = _mapper.Map<OrderVM>(order);
            return View(ord);
        }

        // GET: OrderController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: OrderController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(OrderVM ord)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ord);
                }
                var order = _mapper.Map<Order>(ord);
                var isSuccess = _repo.Create(order);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(ord);
                }
                return RedirectToAction(nameof(Index));
            }
            catch(Exception ex)
            {
                ModelState.AddModelError("", "Check for Information");
                return View();
            }
        }

        // GET: OrderController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var order = _repo.FindById(id);
            var ord = _mapper.Map<OrderVM>(order);
            return View(ord);
        }

        // POST: OrderController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(OrderVM ord)
        {

            try
            {
                if (!ModelState.IsValid)
                {
                    return View(ord);
                }
                var order = _mapper.Map<Order>(ord);
                var isSuccess = _repo.Update(order);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(ord);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(ord);
            }
        }

        // GET: OrderController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = _repo.FindById(id);
            if (order == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(order);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: OrderController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, OrderVM ord)
        {
            try
            {
                var order = _repo.FindById(id);
                if (order == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(order);
                if (!isSuccess)
                {

                    return View(ord);
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
