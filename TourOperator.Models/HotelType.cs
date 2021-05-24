using System;
using System.Collections.Generic;
using System.Text;

namespace TourOperator.Models
{
    public class HotelType
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public List<Hotel> Hotels { get; set; }
    }
}
