using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repositories.Reservation_Services;
using Microsoft.AspNetCore.Authorization;
using System.Data;
using MediaBrowser.Model.Dto;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize(Roles = "customer")]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class ReservationsController : ControllerBase
    {
        private readonly IReservationServices _reservationServices;

        public ReservationsController(IReservationServices reservationServices)
        {
            _reservationServices= reservationServices;
        }

        // GET: api/Reservations
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Reservation>>> GetReservation()
        {
            try
            {
                return Ok(await _reservationServices.GetReservation());
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

       

        // GET: api/Reservations/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Reservation>> GetReservation(int id)
        {
            try
            {
                var reservation_data = await _reservationServices.GetReservation(id);
                if (reservation_data == null) return NotFound("Reservation id not matching");
                return Ok(reservation_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // PUT: api/Reservations/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Reservation>?>> PutReservation(int id, Reservation reservation)
        {
            try
            {
                return await _reservationServices.PutReservation(id, reservation);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        

        // POST: api/Reservations
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Reservation>> PostReservation(Reservation reservation)
        {
            try
            {
                var reservation_data = await _reservationServices.PostReservation(reservation);
                return Ok(reservation_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

       

        // DELETE: api/Reservations/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteReservation(int id)
        {
            try
            {
                var reservation_data = await _reservationServices.DeleteReservation(id);
                if (reservation_data is null)
                {
                    return NotFound("Reservation Id Not matching");
                }
                return Ok(reservation_data);
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
