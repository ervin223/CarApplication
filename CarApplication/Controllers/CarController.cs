using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;
using Microsoft.AspNetCore.Cors.Infrastructure;
using ShopTARgv23.Models;


namespace CarApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly ILogger<CarController> _logger;
        private readonly ICarServices _carService;

        public CarController(ILogger<CarController> logger, ICarServices carService)
        {
            _logger = logger;
            _carService = carService;
        }

        public async Task<IActionResult> Index()
        {
            var cars = await _carService.GetAllAsync();
            return View(cars);
        }

        public IActionResult Create()
        {
            return View();
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _carService.CreateAsync(carDto);
                return RedirectToAction(nameof(Index));
            }

            return View(carDto);
        }

        public async Task<IActionResult> Edit(Guid id)
        {
            var car = await _carService.GetDetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }
            return View(car);
        }

        [HttpPost]
        public async Task<IActionResult> Edit(CarDto carDto)
        {
            if (ModelState.IsValid)
            {
                await _carService.UpdateAsync(carDto);
                return RedirectToAction(nameof(Index));
            }

            return View(carDto);
        }

        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carService.GetDetailsAsync(id);
            if (car == null)
            {
                return NotFound();
            }

            return View(car);
        }

        [HttpPost, ActionName("Delete")]
        public async Task<IActionResult> DeleteConfirmed(Guid id)
        {
            await _carService.DeleteAsync(id);
            return RedirectToAction(nameof(Index));
        }

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}
