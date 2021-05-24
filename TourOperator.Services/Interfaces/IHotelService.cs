using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Services.DtoModels;

namespace TourOperator.Services.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllHotels();

        List<Hotel> GetHotelsWithFilters(string title);

        Hotel GetRecipeById(int id);

        StatusModel CreateHotel(Hotel hotel);

        StatusModel Delete(int id);

        StatusModel Update(Hotel hotel);

        Hotel GetHotelDetails(int id);

        List<Hotel> GetMostRecentHotels(int count);

       
    }
}
