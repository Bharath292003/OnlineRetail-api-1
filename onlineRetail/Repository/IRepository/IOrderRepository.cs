using onlineRetail.Model;

namespace onlineRetail.Repository.IRepository
{
    public interface IOrderRepository
    {
        Task<List<Order>> GetAll();
        Task<Order> GetById(Guid id);
        Task<Order> create(CreateOrder entity);
        Task<bool> update(Guid orderId, int entity);
        Task<bool> delete(Guid orderID);
        Task save();
    }
}
