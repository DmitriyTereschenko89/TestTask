using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
	public class OrderService : IOrderService
	{
		private ApplicationDbContext dbContext;

		public OrderService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<Order> GetOrder()
		{
			return await dbContext.Orders.OrderByDescending(order => order.Price).Include(order => order.User).FirstAsync();			
		}

		public async Task<List<Order>> GetOrders()
		{
			return await dbContext.Orders.Where(order => order.Quantity > 10).Include(order => order.User).ToListAsync();
		}
	}
}
