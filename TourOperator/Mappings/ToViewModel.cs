using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using TourOperator.Models;
using TourOperator.ViewModels;

namespace TourOperator.Mappings
{
    public static class ToViewModel
    {

        public static HotelOverviewModel ToOverviewModel(this Hotel hotel)
        {
            return new HotelOverviewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name,
                Destination = hotel.Destination,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                Views = hotel.Views,
                HotelType = hotel.HotelType.Name
            };
        }

        public static HotelTypeModel ToHotelTypeModel(this HotelType hotelType)
        {
            return new HotelTypeModel()
            {
                Id = hotelType.Id,
                Name = hotelType.Name,
            };
        }

        public static HotelManageOverviewModel ToHotelMangeOverviewModel(this Hotel hotel)
        {
            return new HotelManageOverviewModel()
            {
                Id = hotel.Id,
                Name = hotel.Name
            };
        }

        public static HotelUpdateModel ToHotelUpdateModel(this Hotel hotel)
        {
            return new HotelUpdateModel()
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

        public static HotelDetailsModel ToHotelDetailsModel(this Hotel hotel)
        {
            return new HotelDetailsModel()
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
                Views=hotel.Views

            };

        }

        public static HotelBookingModel ToHotelBookingModel(this Hotel hotel)
        {
            return new HotelBookingModel()
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
                HotelType = hotel.HotelType.ToHotelTypeModel(),
                


            };

        }

    }
}
