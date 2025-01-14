using CarApplication.Core.Dto;
using CarApplication.Core.ServiceInterface;
using CarApplication.Models.Car;
using CarShop.Data;
using Microsoft.AspNetCore.Mvc;

namespace CarApplication.Controllers
{
    public class CarController : Controller
    {
        private readonly CarContext _context;
        private readonly ICarServices _carServices;

        public CarController(CarContext context, ICarServices carServices)
        {
            _context = context;
            _carServices = carServices;
        }

        public IActionResult Index()
        {
            var result = _context.Cars
                .Select(x => new CarIndexViewModel
                {
                    Id = x.Id,
                    Price = x.Price,
                    Brand = x.Brand,
                    Model = x.Model,
                    ModelYear = x.ModelYear,
                });

            return View(result);
        }

        [HttpGet]
        public async Task<IActionResult> Details(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDetailsViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.ModelYear = car.ModelYear;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpGet]
        public IActionResult Create()
        {
            CarCreateUpdateViewModel car = new CarCreateUpdateViewModel();

            return View("CreateUpdate", car);
        }

        [HttpPost]
        public async Task<IActionResult> Create(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                ModelYear = vm.ModelYear,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carServices.Create(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Update(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarCreateUpdateViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.ModelYear = car.ModelYear;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View("CreateUpdate", vm);
        }

        [HttpPost]
        public async Task<IActionResult> Update(CarCreateUpdateViewModel vm)
        {
            var dto = new CarDto()
            {
                Id = vm.Id,
                Brand = vm.Brand,
                Model = vm.Model,
                ModelYear = vm.ModelYear,
                Price = vm.Price,
                CreatedAt = vm.CreatedAt,
                UpdatedAt = vm.UpdatedAt,
            };

            var result = await _carServices.Update(dto);

            if (result == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index), vm);
        }

        [HttpGet]
        public async Task<IActionResult> Delete(Guid id)
        {
            var car = await _carServices.GetAsync(id);

            if (car == null)
            {
                return NotFound();
            }

            var vm = new CarDeleteViewModel();

            vm.Id = car.Id;
            vm.Brand = car.Brand;
            vm.Model = car.Model;
            vm.ModelYear = car.ModelYear;
            vm.Price = car.Price;
            vm.CreatedAt = car.CreatedAt;
            vm.UpdatedAt = car.UpdatedAt;

            return View(vm);
        }

        [HttpPost]
        public async Task<IActionResult> DeleteConfirmation(Guid id)
        {
            var carId = await _carServices.Delete(id);

            if (carId == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return RedirectToAction(nameof(Index));
        }
    }
}
