using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Threading.Tasks;
using TourOperator.Models;

namespace TourOperator.ViewModels
{
    public class HotelCreateModel
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
        public int HotelTypeId { get; set; }

        public List<HotelTypeModel> HotelTypes { get; set; }
    }
}
