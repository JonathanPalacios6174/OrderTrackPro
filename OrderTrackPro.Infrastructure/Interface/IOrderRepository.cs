
namespace OrderTrackPro.Infrastructure.Interface
{
    public interface IOrderRepository
    {
         Task<List<Orders>> GetOrdersAsync();
    }
}
