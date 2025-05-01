
namespace OrderTrackPro.Infrastructure.Interface
{
    public interface IOrderRepository
    {
         Task<List<Order>> GetOrdersAsync();

    }
}
