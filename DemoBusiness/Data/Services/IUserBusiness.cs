using DemoBusiness.Data.ViewModels;
using DemoBusiness.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DemoBusiness.Data.Services
{
    public interface IUserBusiness
    {
        Task<IEnumerable<User>> ListUsersAsync();
        Task<User> GetUserByIdAsync(int id);
        Task<User> SaveUserAsync(int Id, UserVM user);
        Task DeleteUserAsync(int id);
    }
}
