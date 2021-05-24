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

        public HotelController(IHotelService hotelService)
        {
            _hotelService = hotelService;

        }

        [AllowAnonymous]
        public IActionResult Overview(string title)
        {
            var hotels = _hotelService.GetRecipesWithFilters(title);

            var hotelOverviewDataModel = new HotelOverviewDataModel();

            var hotelOverviewModels = hotels.Select(x => x.ToOverviewModel()).ToList();
            hotelOverviewDataModel.OverviewHotels = hotelOverviewModels;
            return View();
        }
    }
}
