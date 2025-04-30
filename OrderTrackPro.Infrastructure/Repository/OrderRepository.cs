
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
            try
            {
                var test = _context.Orders.AsNoTracking().Take(10).ToListAsync();
            }
            catch (Exception ex)
            {

                throw;
            }
            
            return await _context.Orders.AsNoTracking().Take(10).ToListAsync();

        }
    }
}
