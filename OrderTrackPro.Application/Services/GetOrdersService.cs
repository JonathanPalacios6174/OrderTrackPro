using OrderTrackPro.Application.DTOs;
using OrderTrackPro.Application.Interfaces;
using OrderTrackPro.Infrastructure.Interface;   

namespace OrderTrackPro.Application.Services
{
    public class GetOrdersService : IOrderInterfaceService
    {
        private readonly IOrderRepository _orderRepository; 

        public GetOrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<GetOrderDTO>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();
            return (IEnumerable<GetOrderDTO>)orders.ToList();
        }
    }
}
