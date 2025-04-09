using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IUserRepository
    {
        Task<User?> GetByEmailAsync(string email, bool trackChanges);
        Task<User?> GetByIdAsync(long Id, bool trackChanges);
        void CreateUser(User user);
        void UpdateUser(User user);
    }
}
