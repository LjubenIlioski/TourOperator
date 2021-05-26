using Microsoft.AspNetCore.Identity;
using System;

namespace TourOperator.Models
{
    public class ApplicationUser : IdentityUser

    {
        public string City { get; set; }
        
    }
}
