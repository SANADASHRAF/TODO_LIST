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
    public class TaskCategoryRepository : RepositoryBase<TaskCategory>, ITaskCategoryRepository
    {
        public TaskCategoryRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
        }

       
        public async Task<IEnumerable<TaskCategory>> GetAllTaskCategory(bool trackChanges) =>
        await FindAll(trackChanges)
             .ToListAsync();


    }
}