using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Services.DtoModels;

namespace TourOperator.Services.Interfaces
{
    public interface IHotelService
    {
        List<Hotel> GetAllRecipes();

        List<Hotel> GetRecipesWithFilters(string title);

        Hotel GetRecipeById(int id);

        StatusModel CreateRecipe(Hotel hotel);

        StatusModel Delete(int id);

        StatusModel Update(Hotel hotel);

        Hotel GetRecipeDetails(int id);

        List<Hotel> GetMostRecentRecipes(int count);

        List<Hotel> GetTopHotels(int count);
    }
}
