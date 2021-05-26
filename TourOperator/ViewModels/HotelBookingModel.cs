using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOperator.ViewModels
{
    public class HotelBookingModel
    {
        public int Id { get; set; }

        public string Name { get; set; }

        public string Destination { get; set; }

        public string ImageUrl { get; set; }

        public double Price { get; set; }

        public bool Pool { get; set; }

        public bool Bar { get; set; }

        public bool MiniBar { get; set; }

        public string Description { get; set; }

        public int HotelTypeId { get; set; }
        public HotelTypeModel HotelType{ get; set; }


    }
}
