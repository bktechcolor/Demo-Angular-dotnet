using DemoBusiness.Data;
using DemoBusiness.Data.ViewModels;
using DemoBusiness.Models;
using Microsoft.EntityFrameworkCore;

namespace DemoBusiness.Data.Services
{
    public class UserBusiness : IUserBusiness
    {
        private readonly AppDbContext _context;
        public UserBusiness(AppDbContext context)
        {
            _context = context;
        }
        public async Task<IEnumerable<User>> ListUsersAsync()
        {
            return await _context.Users.ToListAsync();
        }
        public async Task<User> GetUserByIdAsync(int id)

        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            return user;
        }
        public async Task<User> SaveUserAsync(int Id, UserVM user)
        {
            var userData = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
            if (userData == null)
            {
                userData = new User();
                _context.Users.Add(userData);
            }
            userData.Name = user.Name;
            userData.Email = user.EmailAddress;
            await _context.SaveChangesAsync();
            return userData;
        }
        public async Task DeleteUserAsync(int id)
        {
            var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == id);
            if (user != null)
            {
                _context.Users.Remove(user);
                await _context.SaveChangesAsync();
            }
        }
    }
}