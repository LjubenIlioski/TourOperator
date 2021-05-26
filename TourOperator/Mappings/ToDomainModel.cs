using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourOperator.Models;
using TourOperator.ViewModels;

namespace TourOperator.Mappings
{
    public static class ToDomainModel
    {
        public static Hotel ToHotelDomainModel(this HotelCreateModel hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                HotelTypeId = hotel.HotelTypeId,
                Pool=hotel.Pool,
                Bar = hotel.Bar,
                MiniBar = hotel.MiniBar,
                Description = hotel.Description,

            };

        }

        public static Hotel ToHotelDomainModel(this HotelUpdateModel hotel)
        {
            return new Hotel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                HotelTypeId = hotel.HotelTypeId,
                Pool = hotel.Pool,
                Bar = hotel.Bar,
                MiniBar = hotel.MiniBar,
                Description = hotel.Description,

            };

        }

        public static Booking ToBookingDomainModel(this BookingViewModel booking)
        {
            return new Booking()
            {

               
                HotelId = booking.HotelId,
                FromDate = booking.FromDate,
                ToDate = booking.ToDate,
                NumberOfPeople = booking.NumberOfPeople,
                NumberOfRooms = booking.NumberOfRooms,
                Name = booking.Name,
                Surname = booking.Surname,
                DateOfBirth = booking.DateOfBirth,
                Email = booking.Email,
                Phone = booking.Phone,
                Address = booking.Address,
                BookingCode = booking.BookingCode,
                BookingStatus = booking.BookingStatus,



            };

        }
    }
}
