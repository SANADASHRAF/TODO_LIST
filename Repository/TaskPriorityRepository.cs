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
    public class TaskPriorityRepository : RepositoryBase<TaskPriority>, ITaskPriorityRepository
    {
        public TaskPriorityRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

       
        public async Task<IEnumerable<TaskPriority>> GetAllTaskPriority(bool trackChanges) =>
        await FindAll(trackChanges)
             .ToListAsync();

    }
}