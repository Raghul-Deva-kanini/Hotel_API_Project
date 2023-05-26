using Hotel.Models;
using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;

namespace Hotel.Repositories.Customer_Services
{
    public class CustomerServices:ICustomerServices
    {
        public HotelDBContext _hotelDBContext;

        public CustomerServices(HotelDBContext hotelDBContext)
        {
            _hotelDBContext= hotelDBContext;
        }

        public async Task<List<Customer>?> GetCustomers()
        {
            var customer_data = await _hotelDBContext.Customers.ToListAsync();
            return customer_data;
        }

        public async Task<Customer> GetCustomer(int id)
        {
            var customer_data = await _hotelDBContext.Customers.FindAsync(id);
            if (customer_data is null)
            {
                return null;
            }
            return customer_data;
        }

        public async Task<List<Customer>?> PutCustomer(int id, Customer customer)
        {
            var customer_data = await _hotelDBContext.Customers.FindAsync(id);
            if (customer_data is null)
            {
                return null;
            }
            customer_data.customer_id = customer.customer_id;
            customer_data.name = customer.name;
            customer_data.email = customer.email;
            customer_data.password = customer.password;
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>> PostCustomer(Customer customer)
        {
            _hotelDBContext.Customers.Add(customer);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Customers.ToListAsync();
        }

        public async Task<List<Customer>> DeleteCustomer(int id)
        {
            var customer_data = _hotelDBContext.Customers.Find(id);
            if (customer_data is null)
            {
                return null;
            }
            _hotelDBContext.Remove(customer_data);
            await _hotelDBContext.SaveChangesAsync();
            return await _hotelDBContext.Customers.ToListAsync();
        }
    }
}
