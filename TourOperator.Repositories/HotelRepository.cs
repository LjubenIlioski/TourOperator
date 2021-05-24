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

        public List<Hotel> GetHotelsWithFilters(string name)
        {
            var query = _context.Hotels.Include(x => x.HotelType);
            var hotels = query.ToList();
            if (name != null)
            {
                var uery = query.Where(x => x.Name.Contains(name));
                hotels = uery.ToList();
            }

         
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
