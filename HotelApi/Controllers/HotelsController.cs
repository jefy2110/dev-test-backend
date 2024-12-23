using Microsoft.AspNetCore.Mvc;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text.Json;
using HotelApi.Models;

namespace HotelApi.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class HotelsController : ControllerBase
    {
        private readonly string _jsonFilePath;

        /// Initializes the controller with a configuration for the JSON file path.
        public HotelsController(IConfiguration configuration)
        {
            _jsonFilePath = configuration["HotelsDataPath"] ?? "Data/hotels.json";
        }

        /// loads and returns the list of hotels from the JSON file.
        private List<Hotel> LoadHotels()
        {
            try
            {
                var json = System.IO.File.ReadAllText(_jsonFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var hotels = JsonSerializer.Deserialize<List<Hotel>>(json, options);
                return hotels ?? new List<Hotel>();
            }
            catch (FileNotFoundException)
            {
                throw new FileNotFoundException("The data file was not found.");
            }
            catch (JsonException)
            {
                throw new JsonException("The data file contains invalid JSON.");
            }
            catch (Exception ex)
            {
                throw new Exception("An unexpected error occurred.", ex);
            }
        }

        [HttpGet]
        
        /// Endpoint for retrieving the list of all hotels.
        public IActionResult GetHotels()
        {
            try
            {
                var hotels = LoadHotels();
                if (!hotels.Any())
                {
                    return NoContent();
                }
                return Ok(hotels);
            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (JsonException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch
            {
                return StatusCode(500, "An error occurred while loading the data.");
            }
        }

        [HttpGet("{id}")]

        /// Endpoint for retrieving the details of a specific hotel by ID.
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var hotels = LoadHotels();
                var hotel = hotels.FirstOrDefault(h => h.Id == id);
                if (hotel == null)
                {
                    return NotFound("Hotel not found.");
                }
                return Ok(hotel);
            }
            catch (FileNotFoundException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch (JsonException ex)
            {
                return StatusCode(500, ex.Message);
            }
            catch
            {
                return StatusCode(500, "An error occurred while loading the data.");
            }
        }
    }
}