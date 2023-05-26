using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repositories.Room_Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using MediaBrowser.Model.Dto;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "admin")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class RoomsController : ControllerBase
    {
        private readonly IRoomServices _roomServices;

        public RoomsController(IRoomServices roomServices)
        {
            _roomServices = roomServices;
        }

        // GET: api/Rooms
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Room>?>> GetRooms()
        {
            try
            {
                return Ok(await _roomServices.GetRooms());
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // GET: api/Rooms/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Room>> GetRoom(int id)
        {
            try
            {
                var room_data = await _roomServices.GetRoom(id);
                if (room_data == null) return NotFound("Room id not matching");
                return Ok(room_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // PUT: api/Rooms/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Room>?>> PutRoom(int id, Room room)
        {
            try
            {
                return await _roomServices.PutRoom(id, room);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // POST: api/Rooms
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Room>> PostRoom(Room room)
        {
            try
            {
                var room_data = await _roomServices.PostRoom(room);
                return Ok(room_data);
            }

            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

       

        // DELETE: api/Rooms/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteRoom(int id)
        {
            try
            {
                var room_data = await _roomServices.DeleteRoom(id);
                if (room_data is null)
                {
                    return NotFound("Room id not matching");
                }
                return Ok(room_data);
            }
            

            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }
        }

        private void LogException(Exception ex)
        {

        }

    }
}
