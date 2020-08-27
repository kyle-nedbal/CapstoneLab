using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using GCCarDealership.Models;
using GCCarDealership.Services;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace FinalCapstoneProject.Controllers
{
    public class CarsController : Controller
    {
        private readonly ICarService _service;

        public CarsController(ICarService service)
        {
            _service = service;
        }

        // GET: Cars
        public async Task<ActionResult> Index()
        {
            var model = await _service.GetAll();
            return View(model);
        }

        //public async Task<ActionResult> Details(int id)
        //{
        //    var model = await _service.Get(id);
        //    return View(model);
        //}

        public async Task<Car> Details(int id)
        {
            var model = await _service.Get(id);
            return model;
        }

        // GET: Books/Create
        public ActionResult Create()
        {
            return View();
        }

        //POST: Books/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Create(Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.Create(car);
                return RedirectToAction(nameof(Index));
            }
            return View();
        }


        // GET: Cars/Edit/5
        public async Task<ActionResult> Edit(int id)
        {
            var model = await _service.Get(id);
            return View(model);
        }

        // POST: Cars/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to, for
        // more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Edit(int id, [Bind("CarID,Make,Model,Year,Color")] Car car)
        {
            if (ModelState.IsValid)
            {
                await _service.Edit(id, car);
                return RedirectToAction(nameof(Index));
            }
            return View(car);
        }

        public async Task<ActionResult> Delete(int id)
        {
            var model = await _service.Get(id);
            return View(model);
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<ActionResult> Delete(int id, IFormCollection collection)
        {
            try
            {
                await _service.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}
