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
    public class EmailVerificationsRepository :RepositoryBase<EmailVerifications>, IEmailVerificationsRepository
    {
        public EmailVerificationsRepository(RepositoryContext repositoryContext)
            : base(repositoryContext)
        {
        }

        public async Task<EmailVerifications?> GetByEmailAsync(string email, bool trackChanges) =>
            await FindByCondition(u => u.Email == email, trackChanges).FirstOrDefaultAsync();

        public void CreateEmailVerifications(EmailVerifications email) => base.Create(email);

       
    }

}
