using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories.Interfaces;
using TourOperator.Services.DtoModels;
using TourOperator.Services.Interfaces;

namespace TourOperator.Services
{
    public class BookingService : IBookingService
    {
        private IBookingRepository _bookingRepository { get; set; }

        public BookingService(IBookingRepository bookingRepository)
        {
            _bookingRepository = bookingRepository;
        }
        StatusModel IBookingService.CreateBooking(Booking booking)
        {
            var response = new StatusModel();

            booking.DateCreated = DateTime.Now;
            _bookingRepository.Add(booking);

            return response;
        }

        StatusModel IBookingService.Delete(int id)
        {
            var response = new StatusModel();
            var booking = _bookingRepository.GetById(id);

            if (booking == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The Booking with id {id} was not found";
            }
            else
            {
                _bookingRepository.Delete(booking);
            }

            return response;
        }

        List<Booking> IBookingService.GetAllBookings()
        {
            return _bookingRepository.GetAll();
        }

        Booking IBookingService.GetBookingById(int id)
        {
            return _bookingRepository.GetById(id);
        }

        StatusModel IBookingService.Update(Booking booking)
        {
            var response = new StatusModel();
            var updatedetBooking = _bookingRepository.GetById(booking.Id);

            if (updatedetBooking != null)
            {
                updatedetBooking.HotelId = booking.HotelId;
                updatedetBooking.FromDate = booking.FromDate;
                updatedetBooking.ToDate = booking.ToDate;
                updatedetBooking.NumberOfPeople = booking.NumberOfPeople;
                updatedetBooking.NumberOfRooms = booking.NumberOfRooms;
                updatedetBooking.Name = booking.Name;
                updatedetBooking.Surname = booking.Surname;
                updatedetBooking.DateOfBirth = booking.DateOfBirth;
                updatedetBooking.Email = booking.Email;
                updatedetBooking.Phone = booking.Phone;
                updatedetBooking.Address = booking.Address;
                updatedetBooking.BookingCode = booking.BookingCode;
                updatedetBooking.BookingStatus = booking.BookingStatus;

                _bookingRepository.Update(updatedetBooking);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The Booking with id {booking.Id} was not found";
            }

            return response;
        }

        public string RandomGenerator(int length)
        {
            Random random = new Random();

            const string chars = "ABCDEFGHIJKLMNOPQRSTUVWXYZ0123456789";
            return new string(Enumerable.Repeat(chars, length)
              .Select(s => s[random.Next(s.Length)]).ToArray());
        }

        Booking IBookingService.GetBookingByProperties(Models.CheckBookingDomain checkBookingDomain)
        {
            return _bookingRepository.GetBookingByProperites(checkBookingDomain);
        }
    }

}
