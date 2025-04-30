using OrderTrackPro.Application.DTOs;

namespace OrderTrackPro.Application.Interfaces
{
    public interface IOrderInterfaceService
    {
        Task<IEnumerable<GetOrderDTO>> GetOrdersAsync();
    }
}
