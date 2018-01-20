namespace DreamVehicle.Web.Controllers
{
    using AutoMapper;
    using DreamVehicle.Services;
    using DreamVehicle.Services.Models;
    using DreamVehicle.Web.Infrastructure.Extensions;
    using DreamVehicle.Web.Models;
    using Microsoft.AspNetCore.Mvc;
    using Microsoft.AspNetCore.Mvc.Rendering;
    using System.Collections.Generic;
    using System.Linq;
    using System.Threading.Tasks;

    using static Infrastructure.Constants.WebConstants;

    public class VehicleController : Controller
    {
        private readonly IVehicleService vehicles;

        public VehicleController(IVehicleService vehicles)
        {
            this.vehicles = vehicles;
        }

        public async Task<IActionResult> Index()
        {
            SearchViewModel model = await this.PrepareSearchViewModel();

            return View(model);
        }

        public IActionResult Add()
        {
            return View();
        }

        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Add(VehicleViewModel vehicleModel)
        {
            if (!ModelState.IsValid)
            {
                return View(vehicleModel);
            }

            var vehicle = Mapper.Map<VehicleServiceModel>(vehicleModel);

            await this.vehicles.Add(vehicle);

            TempData.AddSuccessMessage(AddSuccessMessage);

            return RedirectToAction(nameof(Add));
        }

        public async Task<IActionResult> List(SearchViewModel model)
        {
            var vehiclesFound = await this.vehicles.Search(model.Importer, model.Searched);
            var vehiclesModel = Mapper.Map<List<VehicleViewModel>>(vehiclesFound);

            return View(vehiclesModel);
        }

        private List<SelectListItem> GetImportersOptions(List<string> importers)
        {
            var options = importers.Select(i => new SelectListItem
            {
                Text = i,
                Value = i
            })
            .ToList();

            options.Insert(0, new SelectListItem
            {
                Text = ChooseImporter,
                Value = string.Empty
            });

            return options;
        }

        private async Task<SearchViewModel> PrepareSearchViewModel()
        {
            var importers = await this.vehicles.GetAllImporters();
            var model = new SearchViewModel
            {
                AllImporters = GetImportersOptions(importers)
            };

            return model;
        }
    }
}
