using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IEmailVerificationsRepository
    {
        void CreateEmailVerifications(EmailVerifications email);
        Task<EmailVerifications?> GetByEmailAsync(string email, bool trackChanges);
    }
}
