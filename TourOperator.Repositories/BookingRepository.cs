using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
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

        public Booking GetBookingByProperites(CheckBookingDomain checkBookingDomain)
        {
            return _context.Set<Booking>().Include(x => x.Hotel)
                 .FirstOrDefault(x => x.BookingCode == checkBookingDomain.BookingCode && x.Surname==checkBookingDomain.LastName);
        }

       
    }
}
