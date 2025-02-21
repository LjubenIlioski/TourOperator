﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourOperator.Models
{
    public class Booking
    {

        public int Id { get; set; }
        [Required]
        public int HotelId { get; set; }
        [Required]
        public Hotel Hotel { get; set; }
        [Required]
        public DateTime FromDate { get; set; }
        [Required]
        public DateTime ToDate { get; set; }
        [Required]
        public DateTime  DateCreated { get; set; }
        [Required]
        public int NumberOfPeople { get; set; }
        [Required]
        public int NumberOfRooms { get; set; }
        [Required]
        public string Name { get; set; }
        [Required]
        public string Surname { get; set; }
        [Required]
        public DateTime DateOfBirth { get; set; }
        [Required]
        public string Email { get; set; }
        [Required]
        public string Phone { get; set; }
        [Required]
        public string Address { get; set; }
        [Required]
        public string BookingCode { get; set; }
        [Required]
        public bool BookingStatus { get; set; }
    }
}
