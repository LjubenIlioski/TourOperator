using System;
using System.Collections.Generic;CreateRecipe
using System.Text;
using TourOperator.Models;
using TourOperator.Repositories.Interfaces;
using TourOperator.Services.DtoModels;
using TourOperator.Services.Interfaces;

namespace TourOperator.Services
{
    public class HotelService : IHotelService
    {
        private IHotelRepository _hotelRepository { get; set }

        public HotelService(IHotelRepository hotelRepository)
        {
            _hotelRepository = hotelRepository;
        }





        public StatusModel CreateHotel(Hotel hotel)
        {
            var response = new StatusModel();

            hotel.DateCreated = DateTime.Now;
            _hotelRepository.Add(hotel);

            return response;
        }

        public StatusModel Delete(int id)
        {
            var response = new StatusModel();
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                response.IsSuccessful = false;
                response.Message = $"The hotel with id {id} was not found";
            }
            else
            {
                _hotelRepository.Delete(hotel);
            }

            return response;
        }

        public List<Hotel> GetAllRecipes()
        {
            return _hotelRepository.GetAll();
        }

        public List<Hotel> GetMostRecentRecipes(int count)
        {
            return _hotelRepository.GetMostRecentHotels();


                }

        public Hotel GetRecipeById(int id)
        {
            return _hotelRepository.GetById(id);
        }

        public Hotel GetHotelDetails(int id)
        {
            var hotel = _hotelRepository.GetById(id);

            if (hotel == null)
            {
                return hotel;
            }

            hotel.Views++;

            _hotelRepository.Update(hotel);

            return hotel;
        }

        public List<Hotel> GetRecipesWithFilters(string title)
        {
            return _hotelRepository.GetHotelsWithFilters(title);
        }

        public List<Hotel> GetHotels(int count)
        {
            return _hotelRepository.GetTopHotels(count);
        }

        public StatusModel Update(Hotel hotel)
        {
            var response = new StatusModel();
            var updatedHotel = _hotelRepository.GetById(hotel.Id);

            if (updatedHotel != null)
            {
                updatedHotel.Name = hotel.Name;
                updatedHotel.Destination = hotel.Destination;
                updatedHotel.ImageUrl = hotel.ImageUrl;
                updatedHotel.Price = hotel.Price;
                updatedHotel.Pool = hotel.Pool;
                updatedHotel.Bar = hotel.Bar;
                updatedHotel.MiniBar = hotel.MiniBar;
                updatedHotel.Description = hotel.Description;
                updatedHotel.DateModified = DateTime.Now;
                updatedHotel.HotelTypeId = hotel.HotelTypeId;

                _hotelRepository.Update(updatedHotel);
            }
            else
            {
                response.IsSuccessful = false;
                response.Message = $"The hotel with id {hotel.Id} was not found";
            }

            return response;
        }
    }
}

