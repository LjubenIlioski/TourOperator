using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories.Interfaces;

namespace TourOperator.Repositories
{
    public class BookingRepository : BaseRepository<Booking>, IBookingRepository
    {
        public BookingRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
