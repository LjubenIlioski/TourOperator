using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;

namespace TourOperator.Repositories.Interfaces
{
    public interface IBookingRepository : IBaseRepository<Booking>
    {
        Booking GetBookingByProperites(CheckBookingDomain checkBookingDomain);
    }
}
