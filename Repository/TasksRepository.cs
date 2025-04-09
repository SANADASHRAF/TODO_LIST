using Contract;
using Entities.Models;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using static Microsoft.EntityFrameworkCore.DbLoggerCategory;

namespace Repository
{
    public class TasksRepository:RepositoryBase<Task>,ITasksRepository
    {
        private readonly RepositoryContext _context;
        public TasksRepository(RepositoryContext repositoryContext)
           : base(repositoryContext)
        {
            _context = repositoryContext;
        }

        public async Task<IEnumerable<Tasks>> GetAllTasksAsync(int userId, bool trackChanges, int pageNumber = 1, int pageSize = 10)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .OrderBy(t => t.StartDate)
                .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .Skip((pageNumber - 1) * pageSize)
                .Take(pageSize)
                .ToListAsync();
        }

        public async Task<Tasks> GetTaskByIdAsync(int taskId, bool trackChanges)
        {
            return await _context.Tasks
                .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .FirstOrDefaultAsync(t => t.Id == taskId);
        }

        public async Task<IEnumerable<Tasks>> GetCompletedTasksAsync(int userId, bool trackChanges)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && t.TaskStatusId == 3) 
                .OrderBy(t => t.StartDate)
                .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetPendingTasksAsync(int userId, bool trackChanges)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId && t.TaskStatusId != 3) 
                .OrderBy(t => t.StartDate)
                .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .ToListAsync();
        }

        public async Task<IEnumerable<Tasks>> GetTasksByFilterAsync(int userId, int? statusId, int? categoryId, int? priorityId, bool trackChanges)
        {
            return await _context.Tasks
                .Where(t => t.UserId == userId)
                .Where(t => statusId == null || t.TaskStatusId == statusId)
                .Where(t => categoryId == null || t.TaskCategoryId == categoryId)
                .Where(t => priorityId == null || t.TaskPriorityId == priorityId)
                .OrderBy(t => t.StartDate)
                .AsTracking(trackChanges ? QueryTrackingBehavior.TrackAll : QueryTrackingBehavior.NoTracking)
                .ToListAsync();
        }

        public void CreateTask(Tasks task) => _context.Tasks.Add(task);
        public void UpdateTask(Tasks task) => _context.Tasks.Update(task);
        public void DeleteTask(Tasks task) => _context.Tasks.Remove(task);


    }
}
