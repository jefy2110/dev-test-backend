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
        private readonly string jsonFilePath = "Data/hotels.json";

        [HttpGet]
        public IActionResult GetHotels()
        {
            try
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var hotels = JsonSerializer.Deserialize<List<Hotel  >>(json,options);
                if (hotels == null)
                {
                    return StatusCode(500, "Failed to load hotel data.");
                }
                return Ok(hotels);
            }
            catch
            {
                return StatusCode(500, "An error occurred while reading the data.");
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetHotelById(int id)
        {
            try
            {
                var json = System.IO.File.ReadAllText(jsonFilePath);
                var options = new JsonSerializerOptions
                {
                    PropertyNameCaseInsensitive = true
                };
                var hotels = JsonSerializer.Deserialize<List<Hotel>>(json,options);

                if (hotels == null)
                {
                    return StatusCode(500, "Failed to load hotel data.");
                }

                var hotel = hotels.FirstOrDefault(h => h.Id == id);
                if (hotel == null)
                {
                    return NotFound("Hotel not found.");
                }

                return Ok(hotel);
            }
            catch
            {
                return StatusCode(500, "An error occurred while reading the data.");
            }
        }
    }
}