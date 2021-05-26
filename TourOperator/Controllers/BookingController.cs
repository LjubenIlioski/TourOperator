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
    public class BookingController : Controller
    {
        private IBookingService _bookingService { get; set; }
        private IHotelService _hotelService { get; set; }
        private IHotelTypeService _hotelTypeService { get; set; }

        public BookingController(IHotelService hotelService, IHotelTypeService hotelTypeService, IBookingService bookingService)
        {
            _hotelService = hotelService;
            _hotelTypeService = hotelTypeService;
            _bookingService = bookingService;

        }


        [HttpGet]
        public IActionResult Create(int HotelId)
        {
            var choosenHotel = _hotelService.GetHotelById(HotelId);
            var bookingViewModel = new BookingViewModel();

            bookingViewModel.Hotel = choosenHotel.ToHotelBookingModel();
            bookingViewModel.HotelId = choosenHotel.Id;

            return View(bookingViewModel);
        }

        [HttpPost]
        public IActionResult Create(BookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                var domainModel = booking.ToBookingDomainModel();
                domainModel.BookingCode = _bookingService.RandomGenerator(6);
                var response = _bookingService.CreateBooking(domainModel);

                if (response.IsSuccessful)
                {
                    var userId = User.FindFirst("Id");
                    
                    return RedirectToAction("ManageOverview", new { SuccessMessage = "Booking created sucessfully" });
                }
                else
                {
                    return RedirectToAction("ManageOverview", new { ErrorMessage = response.Message });
                }
            }
            
            return View(booking);
        }
    }
}
