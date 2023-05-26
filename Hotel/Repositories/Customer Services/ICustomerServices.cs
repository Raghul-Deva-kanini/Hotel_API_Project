using Hotel.Models;

namespace Hotel.Repositories.Customer_Services
{
    public interface ICustomerServices
    {
        Task<List<Customer>?> GetCustomers();

        Task<Customer> GetCustomer(int id);

        Task<List<Customer>?> PutCustomer(int id, Customer customer);

        Task<List<Customer>> PostCustomer(Customer customer);

        Task<List<Customer>> DeleteCustomer(int id);
    }
}
