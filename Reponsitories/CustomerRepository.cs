using BusinessObjects;
using DataAccess;
using Repositories.Interface;

namespace Repositories
{
    public class CustomerRepository : ICustomerRepository
    {
        public async Task<Customer> AddCustomer(Customer customer)
        {
            await CustomerDAO.Instance.AddCustomer(customer);
            return customer;
        }

        public async Task DeleteCustomer(int id)
        {
            await CustomerDAO.Instance.DeleteCustomer(id);
        }

        public async Task<IEnumerable<Customer>> GetAllCustomer()
        {
            return await CustomerDAO.Instance.GetCustomerAll();
        }

        public async Task<Customer> GetCustomerById(int id)
        {
            return await CustomerDAO.Instance.GetCustomerById(id);
        }

        public Task<Customer> UpdateCustomer(Customer customer)
        {
            return CustomerDAO.Instance.UpdateCustomer(customer);
        }
    }
}
