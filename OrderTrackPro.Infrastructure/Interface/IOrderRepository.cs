
namespace OrderTrackPro.Infrastructure.Interface
{
    public interface IOrderRepository
    {
         Task<List<Order>> GetOrdersAsync();

         Task<int> CreateOrder(Order order);

         Task<Order?> GetOrderById(int id);

         Task<int> UpdateOrder(Order order);

         Task<int> DeleteOrder(Order order);

        
    }
}
