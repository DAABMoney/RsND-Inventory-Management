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
    public class StaffController : Controller
    {
        private readonly IStaffRepo _repo;
        private readonly IMapper _mapper;

        public StaffController(IStaffRepo repo, IMapper mapper)
        {
            _repo = repo;
            _mapper = mapper;
        }
        // GET: StaffController
        public ActionResult Index()
        {
            var staffs = _repo.FindAll().ToList();
            var model = _mapper.Map<List<Staff>, List<StaffVM>>(staffs);
            return View(model);
        }

        // GET: StaffController/Details/5
        public ActionResult Details(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound();
            }
            var staff = _repo.FindById(id);
            var sta = _mapper.Map<StaffVM>(staff);
            return View(sta);
        }

        // GET: StaffController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: StaffController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(StaffVM sta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sta);
                }
                var staff = _mapper.Map<Staff>(sta);
                staff.Registered = DateTime.Now;
                var isSuccess = _repo.Create(staff);
                if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(sta);
                }

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View();
            }
        }

        // GET: StaffController/Edit/5
        public ActionResult Edit(int id)
        {
            if (!_repo.isExists(id))
            {
                return NotFound(id);
            }
            var staff = _repo.FindById(id);
            var sta = _mapper.Map<StaffVM>(staff);
            return View(sta);
        }

        // POST: StaffController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(StaffVM sta)
        {
            try
            {
                if (!ModelState.IsValid)
                {
                    return View(sta);
                }
                var staff = _mapper.Map<Staff>(sta);
                var isSuccess = _repo.Update(staff);
                    if (!isSuccess)
                {
                    ModelState.AddModelError("", "Check for Information");
                    return View(sta);
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                ModelState.AddModelError("", "Check for Information");
                return View(sta);
            }
        }

        // GET: StaffController/Delete/5
        public ActionResult Delete(int id)
        {
            var staff = _repo.FindById(id);
            if (staff == null)
            {
                return NotFound();
            }
            var isSuccess = _repo.Delete(staff);
            if (!isSuccess)
            {

                return BadRequest();
            }
            return RedirectToAction(nameof(Index));
        }

        // POST: StaffController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, StaffVM sta)
        {
            try
            {
                var staff = _repo.FindById(id);
                if (staff == null)
                {
                    return NotFound();
                }
                var isSuccess = _repo.Delete(staff);
                if (!isSuccess)
                {

                    return View(sta);
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
