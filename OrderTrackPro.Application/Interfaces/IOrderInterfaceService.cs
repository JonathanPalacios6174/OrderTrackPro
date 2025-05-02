using OrderTrackPro.Application.DTOs;
using OrderTrackPro.Domain.Entities;

namespace OrderTrackPro.Application.Interfaces
{
    public interface IOrderInterfaceService
    {
        Task<IEnumerable<OrderDTO>> GetOrdersAsync();

        Task<int> CreateOrder(OrderDTO order);

        Task<int> UpdateOrder(OrderDTO orderDTO);

        Task<int> DeleteOrder(OrderDTO orderDTO);
    }
}
