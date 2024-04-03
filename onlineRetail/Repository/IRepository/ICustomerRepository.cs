using onlineRetail.Model;

namespace onlineRetail.Repository.IRepository
{
    public interface ICustomerRepository
    {
        Task<List<Customer>> GetAll();
        Task<Customer> GetById(Guid id);
        Task<Customer> GetByName(string Name);
        Task<Customer> Create(Customer entity);
        Task<bool> Update(Guid id,Customer entity);
        Task<bool> Delete(Guid id);
        Task save();
    }
}
