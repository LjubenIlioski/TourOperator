using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;

namespace TourOperator.Repositories.Interfaces
{
    public interface IHotelRepository:IBaseRepository<Hotel>
    {

        List<Hotel> GetHotelsWithFilters(string title);
        List<Hotel> GetMostRecentHotels(int count);
        List<Hotel> GetTopHotels(int count);
    }
}
