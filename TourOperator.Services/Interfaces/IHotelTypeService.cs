using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Services.DtoModels;

namespace TourOperator.Services.Interfaces
{
    public interface IHotelTypeService
    {
        List<HotelType> GetAll();
        bool CheckIfExists(int hotelTypeId);


    }
}
