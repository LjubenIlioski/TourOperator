using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;

namespace TourOperator.Repositories
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        public DbSet<Hotel> Hotels { get; set; }
        public DbSet<HotelType> HotelType { get; set; }
        public DbSet<Booking> Bookings { get; set; }
    }
}
