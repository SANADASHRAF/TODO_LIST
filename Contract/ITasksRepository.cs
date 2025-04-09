using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface ITasksRepository
    {
        Task<IEnumerable<Tasks>> GetAllTasksAsync(int userId, bool trackChanges, int pageNumber = 1, int pageSize = 10);
        Task<Tasks> GetTaskByIdAsync(int taskId, bool trackChanges);
        Task<IEnumerable<Tasks>> GetCompletedTasksAsync(int userId, bool trackChanges);
        Task<IEnumerable<Tasks>> GetPendingTasksAsync(int userId, bool trackChanges);
        Task<IEnumerable<Tasks>> GetTasksByFilterAsync(int userId, int? statusId, int? categoryId, int? priorityId, bool trackChanges);
        void CreateTask(Tasks task);
        void UpdateTask(Tasks task);
        void DeleteTask(Tasks task);
    }
}
