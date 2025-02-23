using BusinessObjects;
using Microsoft.AspNetCore.Mvc;
using Repositories.Interface;

namespace ProductManagementAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomerController : ControllerBase
    {
        private readonly ICustomerRepository _CustomerRepository;
        public CustomerController(ICustomerRepository CustomerRepository)
        {
            _CustomerRepository = CustomerRepository;
        }
        // GET: CustomerController
        [HttpGet]
        public async Task<IEnumerable<Customer>> GetCustomer()
        {
            return await _CustomerRepository.GetAllCustomer();
        }

        // GET: CustomerController/Details/5
        [HttpGet("{id}")]
        public async Task<ActionResult<Customer>> GetCustomer(int id)
        {
            var customer = await _CustomerRepository.GetCustomerById(id);

            if (customer == null)
            {
                return NotFound();
            }

            return customer;
        }
        //POST: CustomerController/Create
        [HttpPost]
        public async Task<ActionResult<Customer>> PostCustomer(Customer customer)
        {
            await _CustomerRepository.AddCustomer(customer);
            return CreatedAtAction("GetCustomer", new { id = customer.CustomerId }, customer);
        }
        // PUT: CustomerController/Edit/5
        [HttpPut("{id}")]
        public async Task<IActionResult> PutCustomer(int id, Customer customer)
        {
            var temp = await _CustomerRepository.GetCustomerById(id);
            if (temp == null)
            {
                return NotFound();
            }
            customer.CustomerId = id;
            await _CustomerRepository.UpdateCustomer(customer);
            return Content("Update success");
        }
        // DELETE: CustomerController/Delete/5
        [HttpDelete("{id}")]
        public async Task<IActionResult> DeleteCustomer(int id)
        {
            var customer = await _CustomerRepository.GetCustomerById(id);
            if (customer == null)
            {
                return NotFound();
            }
            await _CustomerRepository.DeleteCustomer(id);
            return Content("Delete success");
        }

    }
}
