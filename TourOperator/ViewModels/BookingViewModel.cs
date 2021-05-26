using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TourOperator.ViewModels
{
    public class BookingViewModel
    {
        public int Id { get; set; }

        public int HotelId { get; set; }

        public HotelBookingModel Hotel { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }

        public int NumberOfPeople { get; set; }

        public int NumberOfRooms { get; set; }

        public string Name { get; set; }

        public string Surname { get; set; }

        public DateTime DateOfBirth { get; set; }

        public string Email { get; set; }
        public string Phone { get; set; }
        public string Address { get; set; }

        public string BookingCode { get; set; }

        public bool BookingStatus { get; set; }
    }
}
