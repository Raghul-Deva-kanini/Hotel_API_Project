using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repositories.Hotel_Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using Microsoft.Extensions.Logging;
using MediaBrowser.Model.Dto;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class HotelTablesController : ControllerBase
    {
        private readonly IHotelServices _hotelServices;

        public HotelTablesController(IHotelServices hotelServices)
        {
            _hotelServices = hotelServices;
        }

        // GET: api/HotelTables
        //[Authorize(Roles = "admin")]
        [HttpGet]
        public async Task<ActionResult<IEnumerable<HotelTable>?>> GetHotels()
        {
            try
            {
                return Ok(await _hotelServices.GetHotels());
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        // GET: api/HotelTables/5
        [HttpGet("{id}")]
        public async Task<ActionResult<HotelTable>> GetHotelTable(int id)
        {
            try
            {
                var hotel_data = await _hotelServices.GetHotelTable(id);
                if (hotel_data == null) return NotFound("Hotel id not matching");
                return Ok(hotel_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        // PUT: api/HotelTables/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<HotelTable>?>> PutHotelTable(int id, HotelTable hotelTable)
        {
            try
            {
                return await _hotelServices.PutHotelTable(id, hotelTable);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        // POST: api/HotelTables
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<HotelTable>> PostHotelTable(HotelTable hotelTable)
        {
            try
            {
                var hotel_data = await _hotelServices.PostHotelTable(hotelTable);
                return Ok(hotel_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        // DELETE: api/HotelTables/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteHotelTable(int id)
        {
            try
            {
                var hotel_data = await _hotelServices.DeleteHotelTable(id);
                if (hotel_data is null)
                {
                    return NotFound("Hotel Id Not matching");
                }
                return Ok(hotel_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpGet]
        [Route("LocationFilter")]
        public IEnumerable<HotelTable> GetLocationDetails(string location)
        {
            try
            {
                return _hotelServices.GetLocationDetails(location).ToList();
            }

            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return (IEnumerable<HotelTable>)StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        [HttpGet]
        [Route("PriceFilter")]
        public IEnumerable<HotelTable> FilterHotels(decimal minPrice, decimal maxPrice)
        {
            try
            {
                return _hotelServices.FilterHotels(minPrice, maxPrice);
            }

            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return (IEnumerable<HotelTable>)StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpGet]
        [Route("AmenitiesFilter")]
        public IEnumerable<HotelTable> AmenitiesFilter(string amenityDescription)
        {
            try
            {
                return _hotelServices.AmenitiesFilter(amenityDescription);
            }

            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return (IEnumerable<HotelTable>)StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        [HttpGet("hotels/{hotelId}/available-room-count")]
        /*public string GetAvailableRoomCount(int hotelId)
        {
            return _hotelServices.GetAvailableRoomCount(hotelId);
        }*/

        public IActionResult GetAvailableRoomCount(int hotelId)
        {
            try
            {
                var availableRooms = _hotelServices.GetAvailableRoomCount(hotelId);
                if (availableRooms == string.Empty)
                {
                    return NotFound($"Hotel with ID {hotelId} not found.");
                }

                return Ok(availableRooms);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError,  "An error occurred while processing the request.");
            }
        }
        private void LogException(Exception ex)
        {
            
        }
    }
}
