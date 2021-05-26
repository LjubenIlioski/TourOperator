using System;
using System.Collections.Generic;
using System.Text;

namespace TourOperator.Models
{
    public class Booking
    {

        public int Id { get; set; }

        public int HotelId { get; set; }

        public Hotel Hotel { get; set; }

        public DateTime FromDate { get; set; }

        public DateTime ToDate { get; set; }
        public DateTime  DateCreated { get; set; }

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
