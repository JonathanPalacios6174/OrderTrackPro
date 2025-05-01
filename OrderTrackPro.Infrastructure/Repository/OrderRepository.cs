
namespace OrderTrackPro.Infrastructure.Repository
{
    public class OrderRepository : IOrderRepository
    {
        private readonly NorthwindContext _context;

        public OrderRepository(NorthwindContext context)
        {
            _context = context;
        }

        public async Task<List<Order>> GetOrdersAsync()
        {
            return await _context.Orders.AsNoTracking().ToListAsync();
        }


        public async Task<int> CreateOrder(Order order)
        {
            await _context.AddAsync(order);

            var result = await _context.SaveChangesAsync();

            return result > 0 ? order.OrderId : 0;
        }


        public async Task<Order?> GetOrderById(int id)
        {
            return await _context.Orders
                .AsNoTracking()
                .FirstOrDefaultAsync(d => d.OrderId == id);
        }


        public async Task<int> UpdateOrder(Order order)
        {
            _context.Update(order);

            return await _context.SaveChangesAsync();
        }


        public async Task<int> DeleteOrder(Order order)
        {
            _context.Remove(order);

            return await _context.SaveChangesAsync();
        }
    }
}
