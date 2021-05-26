using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Services.DtoModels;

namespace TourOperator.Services.Interfaces
{
    public interface IBookingService
    {
        List<Booking> GetAllBookings();

        Booking GetBookingById(int id);

        StatusModel CreateBooking(Booking booking);

        StatusModel Delete(int id);

        StatusModel Update(Booking booking);

        string RandomGenerator(int length);
    }
}
