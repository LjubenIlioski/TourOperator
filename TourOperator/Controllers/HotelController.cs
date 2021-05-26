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
        public IActionResult Overview(string name)
        {
            var hotels = _hotelService.GetHotelsWithFilters(name);

            var hotelOverviewDataModel = new HotelOverviewDataModel();

            var hotelOverviewModels = hotels.Select(x => x.ToOverviewModel()).ToList();
            hotelOverviewDataModel.OverviewHotels = hotelOverviewModels;
            return View(hotelOverviewDataModel);
        }

        public IActionResult ManageOverview(string errorMessage, string successMessage)
        {
            ViewBag.ErrorMessage = errorMessage;
            ViewBag.SuccessMessage = successMessage;
            var hotels = _hotelService.GetAllHotels();

            var viewModels = hotels.Select(x => x.ToHotelMangeOverviewModel()).ToList();

            return View(viewModels);
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
                  
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel created sucessfully" });
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

        [AllowAnonymous]
        public IActionResult AdminDetails(int id)
        {
            try
            {
                var hotel = _hotelService.GetHotelById(id);

                if (hotel == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var hotelDetailsModel = hotel.ToHotelDetailsModel();

                
                return View(hotelDetailsModel);
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        [AllowAnonymous]
        public IActionResult Details(int id)
        {
            try
            {
                var hotel = _hotelService.GetHotelById(id);

                if (hotel == null)
                {
                    return RedirectToAction("ErrorNotFound", "Info");
                }

                var hotelDetailsModel = hotel.ToHotelDetailsModel();


                return View(hotelDetailsModel);
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }



        public IActionResult Delete(int id)
        {
            try
            {
                var response = _hotelService.Delete(id);

                if (response.IsSuccessful)
                {
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel deleted sucessfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }
            catch (Exception)
            {
                return RedirectToAction("InternalError", "Info");
            }
        }

        [HttpGet]
        public IActionResult Update(int id)
        {
            var hotel = _hotelService.GetHotelById(id);

            if (hotel == null)
            {
                return RedirectToAction("ManageOverview", new { ErrorMessage = "Hotel not found" });
            }

            var viewModel = hotel.ToHotelUpdateModel();

            var recipeTypes = _hotelTypeService.GetAll();
            var viewModels = recipeTypes.Select(x => x.ToHotelTypeModel()).ToList();

            viewModel.HotelTypes = viewModels;

            return View(viewModel);
        }

        [HttpPost]
        public IActionResult Update(HotelUpdateModel hotel)
        {
            if (ModelState.IsValid)
            {
                try
                {
                    var response = _hotelService.Update(hotel.ToHotelDomainModel());

                    if (response.IsSuccessful)
                    {
                        return RedirectToAction("ManageOverview", new { SuccessMessage = "Hotel updated successfuly" });
                    }
                    else
                    {
                        return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                    }
                }
                catch (Exception)
                {
                    return RedirectToAction("InternalError", "Info");
                }
            }

            return View(hotel);
        }



    }
}
