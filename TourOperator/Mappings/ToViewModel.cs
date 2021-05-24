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

       
    }
}
