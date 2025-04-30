
namespace OrderTrackPro.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Orders>> GetOrdersAsync()
        {
           return await _context.Orders.AsNoTracking().Take(10).ToListAsync();

        }
    }
}
