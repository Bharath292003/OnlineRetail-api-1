using onlineRetail.Model;

namespace onlineRetail.Repository.IRepository
{
    public interface IProductRepository
    {
        Task<List<Product>> GetAll();
        Task<Product> GetById(Guid id);
        Task<Product> GetByName(string Name);
        Task<Product> Create(Product entity);
        Task<bool> Update(Guid id, Product entity);
        Task<bool> Delete(Guid id);
        Task save();
    }
}
