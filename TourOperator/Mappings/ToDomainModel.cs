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
                Destination = hotel.Description,
                ImageUrl = hotel.ImageUrl,
                Price = hotel.Price,
                HotelTypeId = hotel.HotelTypeId,
                Pool=hotel.Pool,
                Bar = hotel.Bar,
                MiniBar = hotel.MiniBar,
                Description = hotel.Description,

            };

        }
    }
}
