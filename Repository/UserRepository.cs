using Contract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class UserRepository : RepositoryBase<User>, IUserRepository
    {
        public UserRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<User?> GetByEmailAsync(string email, bool trackChanges) =>
             await FindByCondition(u => u.Email == email, trackChanges).FirstOrDefaultAsync();

        public async Task<User?> GetByIdAsync(long Id, bool trackChanges) =>
            await FindByCondition(u => u.Id == Id, trackChanges).FirstOrDefaultAsync();

        public void CreateUser(User user) => Create(user);
        public void UpdateUser(User user) => Update(user);
    }
}
