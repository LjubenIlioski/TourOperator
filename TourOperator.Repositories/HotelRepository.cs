using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories.Interfaces;

namespace TourOperator.Repositories
{
    public class HotelRepository:BaseRepository<Hotel>, IHotelRepository
    {
        public HotelRepository(ApplicationDbContext context):base(context)
        {

        }

        public List<Hotel> GetHotelsWithFilters(string title)
        {
            var query = _context.Hotels.Include(x => x.HotelType);

            if (title != null)
            {
                query.Where(x => x.Name.Contains(title));
            }

            var hotels = query.ToList();

            return hotels;
        }

        public List<Hotel> GetMostRecentHotels(int count)
        {
            return _context.Hotels.OrderByDescending(x => x.DateCreated).Take(count).ToList();
        }

        public List<Hotel> GetTopHotels(int count)
        {
            return _context.Hotels.OrderByDescending(x => x.Views).Take(count).ToList();
        }
    }
}
