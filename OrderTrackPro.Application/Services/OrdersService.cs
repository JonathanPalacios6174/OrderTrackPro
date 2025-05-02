using OrderTrackPro.Application.DTOs;
using OrderTrackPro.Application.Interfaces;
using OrderTrackPro.Domain.Entities;
using OrderTrackPro.Infrastructure.Interface;   

namespace OrderTrackPro.Application.Services
{
    public class OrdersService : IOrderInterfaceService
    {
        private readonly IOrderRepository _orderRepository; 

        public OrdersService(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        public async Task<IEnumerable<OrderDTO>> GetOrdersAsync()
        {
            var orders = await _orderRepository.GetOrdersAsync();

            return orders.Select(s => new OrderDTO
            {
                OrderId = s.OrderId,
                CustomerId = s.CustomerId,
                EmployeeId = s.EmployeeId,
                OrderDate = s.OrderDate,
                RequiredDate = s.RequiredDate,
                ShippedDate = s.ShippedDate,
                ShipVia = s.ShipVia,
                Freight = s.Freight,
                ShipName = s.ShipName,
                ShipAddress = s.ShipAddress,
                ShipCity = s.ShipCity,
                ShipRegion = s.ShipRegion,
                ShipPostalCode = s.ShipPostalCode,
                ShipCountry = s.ShipCountry
            });
        }

        public async Task<int> CreateOrder(OrderDTO orderDTO)
        {
            var order = new Order
            {
                CustomerId = orderDTO.CustomerId,
                EmployeeId = orderDTO.EmployeeId,
                OrderDate = orderDTO.OrderDate,
                RequiredDate = orderDTO.RequiredDate,
                ShippedDate = orderDTO.ShippedDate,
                ShipVia = orderDTO.ShipVia,
                Freight = orderDTO.Freight,
                ShipName = orderDTO.ShipName,
                ShipAddress = orderDTO.ShipAddress,
                ShipCity = orderDTO.ShipCity,
                ShipRegion = orderDTO.ShipRegion,
                ShipPostalCode = orderDTO.ShipPostalCode,
                ShipCountry = orderDTO.ShipCountry,
                OrderDetails = orderDTO.OrderDetails.Select(od => new OrderDetail
                {
                    ProductId = od.ProductId,
                    UnitPrice = od.UnitPrice,
                    Quantity = od.Quantity,
                    Discount = od.Discount
                }).ToList()
            };
            var orders = await _orderRepository.CreateOrder(order);

            return orders;
        }

        public async Task<int> UpdateOrder(OrderDTO orderDTO)
        {
           var order = await _orderRepository.GetOrderById(orderDTO.OrderId);

            if (order == null)
            {
                return 0;
            }

            //order.CustomerId = orderDTO.CustomerId;
            order.CustomerId = string.IsNullOrWhiteSpace(orderDTO.CustomerId) ? order.CustomerId : orderDTO.CustomerId;
            order.EmployeeId = orderDTO.EmployeeId.HasValue ? orderDTO.EmployeeId : order.EmployeeId;
            order.OrderDate = orderDTO.OrderDate.HasValue ? orderDTO.OrderDate : order.OrderDate;
            order.RequiredDate = orderDTO.RequiredDate.HasValue ? orderDTO.RequiredDate : order.RequiredDate;
            order.ShippedDate = orderDTO.ShippedDate.HasValue ? orderDTO.ShippedDate : order.ShippedDate;
            order.ShipVia = orderDTO.ShipVia.HasValue ? orderDTO.ShipVia : order.ShipVia;
            order.Freight = orderDTO.Freight.HasValue ? orderDTO.Freight : order.Freight;
            order.ShipName = string.IsNullOrWhiteSpace(orderDTO.ShipName) ? order.ShipName: orderDTO.ShipName;
            order.ShipAddress = string.IsNullOrWhiteSpace(orderDTO.ShipAddress) ? order.ShipAddress : orderDTO.ShipAddress;
            order.ShipCity = string.IsNullOrWhiteSpace(orderDTO.ShipCity) ? order.ShipCity : orderDTO.ShipCity;
            order.ShipRegion = string.IsNullOrWhiteSpace(orderDTO.ShipRegion) ? order.ShipRegion : orderDTO.ShipRegion;
            order.ShipPostalCode = string.IsNullOrWhiteSpace(orderDTO.ShipPostalCode) ? order.ShipPostalCode : orderDTO.ShipPostalCode;
            order.ShipCountry = string.IsNullOrWhiteSpace(orderDTO.ShipCountry) ? order.ShipCountry : orderDTO.ShipCountry;

           

            return await _orderRepository.UpdateOrder(order);
        }

        public async Task<int> DeleteOrder(OrderDTO orderDTO)
        {
            var order = await _orderRepository.GetOrderById(orderDTO.OrderId);

            if (order == null)
            {
                return 0;
            }
            var result = await _orderRepository.DeleteOrder(order);
            return result;

        }



    }
}
