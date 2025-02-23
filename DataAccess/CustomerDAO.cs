using BusinessObjects;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DataAccess
{
    public class CustomerDAO : SingletonBase<CustomerDAO>
    {
        public async Task<IEnumerable<Customer>> GetCustomerAll()
        {
            return await _context.Customers.ToListAsync();
        }
        public async Task<Customer> GetCustomerById(int id)
        {
            var customer = await _context.Customers.FirstOrDefaultAsync(c => c.CustomerId == id);
            if (customer == null) return null;
            return customer;
        }
        public async Task<Customer> AddCustomer(Customer customer)
        {
            _context.Customers.Add(customer);
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<Customer> UpdateCustomer(Customer customer)
        {
            var existingCustomer = await GetCustomerById(customer.CustomerId);
            if (existingCustomer != null)
            {
                _context.Entry(existingCustomer).CurrentValues.SetValues(customer);
            }
            else
            {
                _context.Customers.Add(customer);

            }
            await _context.SaveChangesAsync();
            return customer;
        }
        public async Task<bool> DeleteCustomer(int id)
        {
            var customer = await GetCustomerById(id);
            if (customer == null) return false;
            _context.Customers.Remove(customer);
            await _context.SaveChangesAsync();
            return true;
        }
    }
}
