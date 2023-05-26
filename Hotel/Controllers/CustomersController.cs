using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Hotel.Models;
using Hotel.Repositories.Customer_Services;
using MediaBrowser.Model.Dto;

namespace Hotel.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [ProducesResponseType(typeof(UserDto), StatusCodes.Status200OK)]
    [ProducesResponseType(typeof(string), StatusCodes.Status404NotFound)]
    [ProducesResponseType(typeof(string), StatusCodes.Status500InternalServerError)]
    public class CustomersController : ControllerBase
    {
        private readonly ICustomerServices _customerServices;

        public CustomersController(ICustomerServices customerServices)
        {
            _customerServices = customerServices;
        }

        // GET: api/Customers
        [HttpGet]
        public async Task<ActionResult<IEnumerable<Customer>>> GetCustomers()
        {
            try
            {
                return Ok(await _customerServices.GetCustomers());
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }

        

        // GET: api/Customers/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            try
            {
                var customer_data = await _customerServices.GetCustomer(id);
                if (customer_data == null) return NotFound("CUstomer id not matching");
                return Ok(customer_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // PUT: api/Customers/5
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPut("{id}")]
        public async Task<ActionResult<List<Customer>?>> PutCustomer(int id, Customer customer)
        {
            try
            {
                return await _customerServices.PutCustomer(id, customer);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // POST: api/Customers
        // To protect from overposting attacks, see https://go.microsoft.com/fwlink/?linkid=2123754
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            try
            {
                var customer_data = await _customerServices.PostCustomer(customer);
                return Ok(customer_data);
            }
            catch (Exception ex)
            {
                // Log the exception for further investigation
                LogException(ex);

                // Return a generic error message
                return StatusCode(StatusCodes.Status500InternalServerError, "An error occurred while processing the request.");
            }

        }


        // DELETE: api/Customers/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            try
            {
                var customer_data = await _customerServices.DeleteCustomer(id);
                if (customer_data is null)
                {
                    return NotFound("Customer Id Not matching");
                }
                return Ok(customer_data);
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
