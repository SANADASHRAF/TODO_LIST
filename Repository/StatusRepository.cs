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
    public class StatusRepository : RepositoryBase<Status>, IStatusRepository
    {
        public StatusRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

        public async Task<IEnumerable<Status>> GetAllStutus(bool trackChanges) =>
        await FindAll(trackChanges)
             .ToListAsync();


    }
}
