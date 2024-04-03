using Microsoft.AspNetCore.Http.HttpResults;
using Microsoft.EntityFrameworkCore;
using onlineRetail.Model;
using onlineRetail.Repository.IRepository;

namespace onlineRetail.Repository
{
    public class CustomerRepository : ICustomerRepository
    {
        private readonly CombineContext _dbcontext;
        public CustomerRepository(CombineContext dbcontext)
        {
            _dbcontext = dbcontext;
        }
        public async Task<Customer> Create(Customer entity)
        {
            entity.customerId = Guid.NewGuid();
            _dbcontext.Customer.Add(entity);
            await save();
            return entity;
        }

        public async Task<bool> Delete(Guid id)
        {
            var customer = await _dbcontext.Customer.FindAsync(id);
            if(customer==null)
            {
                return false;
            }
            _dbcontext.Customer.Remove(customer);
            await save() ;
            return true;
           
        }

        public async Task<List<Customer>> GetAll()
        {
            List<Customer> customers = await _dbcontext.Customer.ToListAsync();
            return customers;
        }

        public async Task<Customer> GetById(Guid id)
        {
            Customer customer = await _dbcontext.Customer.FindAsync(id);
            return customer;

        }

        public async Task<Customer> GetByName(string Name)
        {
            Customer customer = await _dbcontext.Customer.FirstOrDefaultAsync(Off => Off.customerName == Name);
            return customer;
        }

        public async Task save()
        {
            await _dbcontext.SaveChangesAsync();
        }

        public async Task<bool> Update(Guid id,Customer entity)
        {
            if(id != entity.customerId)
            {
                return false;
            }
            _dbcontext.Entry(entity).State = EntityState.Modified;
            await _dbcontext.SaveChangesAsync();
            return true;

        }
        public bool OrderProductAvailable(Guid customerId)
        {
            return _dbcontext.Customer.Any(c => c.customerId == customerId);
        }

     
    }
}
