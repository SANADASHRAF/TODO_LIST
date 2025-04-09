using Shared.DataTransferObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface ITaskService
    {
        Task<ServiceResponse<IEnumerable<TaskDto>>> GetAllTasksAsync(int userId, bool trackChanges, int pageNumber = 1, int pageSize = 10);
        Task<ServiceResponse<TaskDto>> GetTaskByIdAsync(int taskId, bool trackChanges);
        Task<ServiceResponse<IEnumerable<TaskDto>>> GetCompletedTasksAsync(int userId, bool trackChanges);
        Task<ServiceResponse<IEnumerable<TaskDto>>> GetPendingTasksAsync(int userId, bool trackChanges);
        Task<ServiceResponse<IEnumerable<TaskDto>>> GetTasksByFilterAsync(int userId, int? statusId, int? categoryId, int? priorityId, bool trackChanges);
        Task<ServiceResponse<TaskDto>> CreateTaskAsync(CreateTaskDto createTaskDto);
        Task<ServiceResponse<TaskDto>> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto);
        Task<ServiceResponse<TaskDto>> UpdateTaskStatusAsync(int taskId, int statusId);
        Task<ServiceResponse<bool>> DeleteTaskAsync(int taskId);
    }
}
