using AutoMapper;
using Contract;
using Entities.Models;
using Service.Contracts;
using Shared.DataTransferObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class TaskService : ITaskService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;

        public TaskService(IRepositoryManager repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

       
        public async Task<ServiceResponse<IEnumerable<TaskDto>>> GetAllTasksAsync(int userId, bool trackChanges, int pageNumber = 1, int pageSize = 10)
        {
            try
            {
                var tasks = await _repository.TasksRepository.GetAllTasksAsync(userId, trackChanges);
                var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
                return new ServiceResponse<IEnumerable<TaskDto>>(true, "تم جلب جميع المهام بنجاح", tasksDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskDto>>(false,  ex.Message, null);
            }
        }
       

        public async Task<ServiceResponse<TaskDto>> GetTaskByIdAsync(int taskId, bool trackChanges)
        {
            try
            {
                var task = await _repository.TasksRepository.GetTaskByIdAsync(taskId, trackChanges);
                if (task == null)
                    return new ServiceResponse<TaskDto>(false, "المهمة غير موجودة", null);

                var taskDto = _mapper.Map<TaskDto>(task);
                return new ServiceResponse<TaskDto>(true, "تم جلب المهمة بنجاح", taskDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TaskDto>(false, ex.Message, null);
            }
        }
       

       
        public async Task<ServiceResponse<IEnumerable<TaskDto>>> GetCompletedTasksAsync(int userId, bool trackChanges)
        {
            try
            {
                var tasks = await _repository.TasksRepository.GetCompletedTasksAsync(userId, trackChanges);
                var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
                return new ServiceResponse<IEnumerable<TaskDto>>(true, "تم جلب المهام المكتملة بنجاح", tasksDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskDto>>(false,  ex.Message, null);
            }
        }
       

        
        public async Task<ServiceResponse<IEnumerable<TaskDto>>> GetPendingTasksAsync(int userId, bool trackChanges)
        {
            try
            {
                var tasks = await _repository.TasksRepository.GetPendingTasksAsync(userId, trackChanges);
                var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
                return new ServiceResponse<IEnumerable<TaskDto>>(true, "تم جلب المهام غير المكتملة بنجاح", tasksDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskDto>>(false, ex.Message, null);
            }
        }
      

       
        public async Task<ServiceResponse<IEnumerable<TaskDto>>> GetTasksByFilterAsync(int userId, int? statusId, int? categoryId, int? priorityId, bool trackChanges)
        {
            try
            {
                var tasks = await _repository.TasksRepository.GetTasksByFilterAsync(userId, statusId, categoryId, priorityId, trackChanges);
                var tasksDto = _mapper.Map<IEnumerable<TaskDto>>(tasks);
                return new ServiceResponse<IEnumerable<TaskDto>>(true, "تم جلب المهام المفلترة بنجاح", tasksDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskDto>>(false, ex.Message, null);
            }
        }
    
     
        public async Task<ServiceResponse<TaskDto>> CreateTaskAsync(CreateTaskDto createTaskDto)
        {
            try
            {
                var task = _mapper.Map<Tasks>(createTaskDto);
                task.StartDate = DateTime.UtcNow;

                _repository.TasksRepository.CreateTask(task);
                _repository.Save();

                var taskDto = _mapper.Map<TaskDto>(task);
                return new ServiceResponse<TaskDto>(true, "تم إنشاء المهمة بنجاح", taskDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TaskDto>(false, ex.Message, null);
            }
        }



        public async Task<ServiceResponse<TaskDto>> UpdateTaskAsync(int taskId, UpdateTaskDto updateTaskDto)
        {
            try
            {
                var task = await _repository.TasksRepository.GetTaskByIdAsync(taskId, trackChanges: true);
                if (task == null)
                    return new ServiceResponse<TaskDto>(false, "المهمة غير موجودة", null);

                _mapper.Map(updateTaskDto, task);
                _repository.TasksRepository.UpdateTask(task);
                _repository.Save();

                var taskDto = _mapper.Map<TaskDto>(task);
                return new ServiceResponse<TaskDto>(true, "تم تعديل المهمة بنجاح", taskDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TaskDto>(false, ex.Message, null);
            }
        }
        
    
        public async Task<ServiceResponse<TaskDto>> UpdateTaskStatusAsync(int taskId, int statusId)
        {
            try
            {
                var task = await _repository.TasksRepository.GetTaskByIdAsync(taskId, trackChanges: true);
                if (task == null)
                    return new ServiceResponse<TaskDto>(false, "المهمة غير موجودة", null);

                task.TaskStatusId = statusId;
                _repository.TasksRepository.UpdateTask(task);
                _repository.Save();

                var taskDto = _mapper.Map<TaskDto>(task);
                return new ServiceResponse<TaskDto>(true, "تم تحديث حالة المهمة بنجاح", taskDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<TaskDto>(false, $"حدث خطأ: {ex.Message}", null);
            }
        }
       

       
        public async Task<ServiceResponse<bool>> DeleteTaskAsync(int taskId)
        {
            try
            {
                var task = await _repository.TasksRepository.GetTaskByIdAsync(taskId, trackChanges: true);
                if (task == null)
                    return new ServiceResponse<bool>(false, "المهمة غير موجودة", false);

                _repository.TasksRepository.DeleteTask(task);
                _repository.Save();

                return new ServiceResponse<bool>(true, "تم حذف المهمة بنجاح", true);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<bool>(false, ex.Message, false);
            }
        }
    
    }
}
