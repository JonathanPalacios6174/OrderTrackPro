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

            var orderDTOs = orders.Select(order => new GetOrderDTO
            {
                OrderId = order.OrderId,
                CustomerId = order.CustomerId,
                EmployeeId = order.EmployeeId,
                OrderDate = order.OrderDate,
                RequiredDate = order.RequiredDate,
                ShippedDate = order.ShippedDate,
                ShipVia = order.ShipVia,
                Freight = order.Freight,
                ShipName = order.ShipName,
                ShipAddress = order.ShipAddress,
                ShipCity = order.ShipCity,
                ShipRegion = order.ShipRegion,
                ShipPostalCode = order.ShipPostalCode,
                ShipCountry = order.ShipCountry
            });

            return (IEnumerable<GetOrderDTO>)orders.ToList();
        }
    }
}
