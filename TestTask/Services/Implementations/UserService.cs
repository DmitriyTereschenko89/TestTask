using Microsoft.EntityFrameworkCore;
using TestTask.Data;
using TestTask.Enums;
using TestTask.Models;
using TestTask.Services.Interfaces;

namespace TestTask.Services.Implementations
{
	public class UserService : IUserService
	{
		private ApplicationDbContext dbContext;

		public UserService(ApplicationDbContext dbContext)
		{
			this.dbContext = dbContext;
		}

		public async Task<User> GetUser()
		{
			return await dbContext.Users.OrderByDescending(user => user.Orders.Count).Include(user => user.Orders).FirstAsync();
		}

		public async Task<List<User>> GetUsers()
		{
			return await dbContext.Users.Where(user => user.Status == UserStatus.Inactive).Include(user => user.Orders).ToListAsync();
		}
	}
}
