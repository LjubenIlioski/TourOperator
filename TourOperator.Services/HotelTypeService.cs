using System;
using System.Collections.Generic;
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories;
using TourOperator.Repositories.Interfaces;
using TourOperator.Services.DtoModels;
using TourOperator.Services.Interfaces;

namespace TourOperator.Services
{
    public class HotelTypeService : IHotelTypeService
    {
        private readonly IHotelTypeRepository _hotelTypeRepository;


        public HotelTypeService(IHotelTypeRepository hotelTypeRepository)
        {
            _hotelTypeRepository = hotelTypeRepository;
        }
        public bool CheckIfExists(int hotelTypeId)
        {
            var recipeType = _hotelTypeRepository.GetById(hotelTypeId);

            return recipeType != null; ;
        }

        public List<HotelType> GetAll()
        {
            return _hotelTypeRepository.GetAll();
        }
    }
}

