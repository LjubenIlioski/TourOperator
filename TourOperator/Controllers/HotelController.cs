using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourOperator.Mappings;
using TourOperator.Services.Interfaces;
using TourOperator.ViewModels;

namespace TourOperator.Controllers
{
    public class HotelController : Controller
    {
        private IHotelService _hotelService { get; set; }
        private IHotelTypeService _hotelTypeService { get; set; }

    public HotelController(IHotelService hotelService,IHotelTypeService hotelTypeService)
        {
            _hotelService = hotelService;
            _hotelTypeService = hotelTypeService;

        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var hotels = _hotelService.GetHotelsWithFilters(title);

            var hotelOverviewDataModel = new HotelOverviewDataModel();

            var hotelOverviewModels = hotels.Select(x => x.ToOverviewModel()).ToList();
            hotelOverviewDataModel.OverviewHotels = hotelOverviewModels;
            return View(hotelOverviewDataModel);
        }

        [HttpGet]
        public IActionResult Create()
        {
            var hotelTypes = _hotelTypeService.GetAll();
            var viewModels = hotelTypes.Select(x => x.ToHotelTypeModel()).ToList();

            var viewModel = new HotelCreateModel();
            viewModel.HotelTypes = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Create(HotelCreateModel hotel)
        {
            if (ModelState.IsValid)
            {
                var domainModel = hotel.ToHotelDomainModel();
                var response = _hotelService.CreateHotel(domainModel);

                if (response.IsSuccessful)
                {
                    var userId = User.FindFirst("Id");
                  
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Recipe created sucessfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }

            var hotelTypes = _hotelTypeService.GetAll();
            var viewModels = hotelTypes.Select(x => x.ToHotelTypeModel()).ToList();

            hotel.HotelTypes = viewModels;

            return View(hotel);
        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var hotels = _hotelService.GetAllHotels();

            var viewModels = hotels.Select(x => x.ToOverviewModel()).ToList();

            return View(viewModels);
        }



    }
}
