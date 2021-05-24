using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories.Interfaces;

namespace TourOperator.Repositories
{
    public class HotelTypeRepository : BaseRepository<HotelType>, IHotelTypeRepository
    {
        public HotelTypeRepository(ApplicationDbContext context) : base(context)
        {
        }
    }
}
