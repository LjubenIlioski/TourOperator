using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourOperator.Mappings;
using TourOperator.Models;
using TourOperator.Services.DtoModels;
using TourOperator.Services.Interfaces;
using TourOperator.ViewModels;

namespace TourOperator.Controllers
{
    [Authorize]
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

        [AllowAnonymous]
        [HttpGet]
        public IActionResult Create(int HotelId)
        {
            var choosenHotel = _hotelService.GetHotelById(HotelId);
            var bookingViewModel = new BookingViewModel();

            bookingViewModel.Hotel = choosenHotel.ToHotelBookingModel();
            bookingViewModel.HotelId = choosenHotel.Id;

            return View(bookingViewModel);
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult Create(BookingViewModel booking)
        {
            if (ModelState.IsValid)
            {
                var domainModel = booking.ToBookingDomainModel();
                domainModel.BookingCode = _bookingService.RandomGenerator(6);
                var response = _bookingService.CreateBooking(domainModel);

                var bookingResult = new BookingResult();
                bookingResult.IsSuccessful = response.IsSuccessful;
                bookingResult.Code = domainModel.BookingCode;


                if (response.IsSuccessful)
                {
                    bookingResult.Message = "Booking created sucessfully";
                    return RedirectToAction("BookingResult", bookingResult);
                }
                else
                {
                    bookingResult.Message = response.Message;
                    return RedirectToAction("BookingResult", bookingResult);
                }
            }

            return View(booking);
        }
        [AllowAnonymous]
        public IActionResult BookingResult(BookingResult bookingResult)
        {
            return View(bookingResult);
        }
        [AllowAnonymous]
        [HttpGet]
        public IActionResult CheckBooking(string statusMessage)
        {
            ViewBag.StatusMessage = statusMessage;
            return View();
        }
        [AllowAnonymous]
        [HttpPost]
        public IActionResult CheckBooking(CheckBooking checkBooking)
        {
       
            var checkBookingDomain = checkBooking.ToCheckBookingDomainModel();
            var booking = new Booking();

            booking = _bookingService.GetBookingByProperties(checkBookingDomain);

            

            if (booking == null)
            {
                return RedirectToAction("CheckBooking", new { StatusMessage = "Booking not found. Please try again" });
            }

            var bookingViewModel = booking.ToBookingViewModel();

            return RedirectToAction("BookingStatus", bookingViewModel);
        }
        [AllowAnonymous]
        public IActionResult BookingStatus(BookingViewModel bookingViewModel)
        {
            return View(bookingViewModel);
        }
        [Authorize(Roles = "Admin,CustomerSupport")]
        public IActionResult Overview()
        {
            var bookings = _bookingService.GetAllBookings();

            var bookingViewDataModel = new BookingViewDataModel();

            var bookingViewModels = bookings.Select(x => x.ToBookingViewModel()).ToList();
            bookingViewDataModel.OverviewBookings = bookingViewModels;
            return View(bookingViewDataModel);
        }
        [Authorize(Roles = "Admin,CustomerSupport")]
        public IActionResult ChangeStatus(int id)
        {
            var booking = _bookingService.GetBookingById(id);

            var status = booking.BookingStatus;

            if (status)
            {
                booking.BookingStatus = false;
            }
            else
            {
                booking.BookingStatus = true;
            }

            var response = _bookingService.Update(booking);

            var bookingResult = new BookingResult();
            bookingResult.IsSuccessful = response.IsSuccessful;
            bookingResult.Code = null;


            if (response.IsSuccessful)
            {
                bookingResult.Message = "Booking status changed sucessfully";
                return RedirectToAction("BookingResult", bookingResult);
            }
            else
            {
                bookingResult.Message = response.Message;
                return RedirectToAction("BookingResult", bookingResult);
            }

           
        }

    }
}
