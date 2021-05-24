using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace TourOperator.Models
{
    public class Hotel
    {
        public int Id { get; set; }

        [Required]
        [StringLength(maximumLength: 50, MinimumLength = 5)]
        public string Name { get; set; }

        [Required]
        public string Destination { get; set; }

        [Required]
        public string ImageUrl { get; set; }

        [Required]
        public double Price { get; set; }

        [Required]
        public bool Pool { get; set; }

        [Required]
        public bool Bar { get; set; }

        [Required]
        public bool MiniBar { get; set; }

        [Required]
        public string Description { get; set; }

        [Required]
        public DateTime DateCreated { get; set; }

        public DateTime? DateModified { get; set; }

        public int Views { get; set; }

        public int HotelTypeId { get; set; }
        public HotelType HotelType { get; set; }
    }
}
