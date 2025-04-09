using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITaskCategoryRepository
    {
        Task<IEnumerable<TaskCategory>> GetAllTaskCategory(bool trackChanges);
    }
}
