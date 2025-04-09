using AutoMapper;
using Contract;
using Microsoft.Extensions.Configuration;
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
    public class StaticService : IStaticService
    {
        private readonly IRepositoryManager _repository;
        private readonly IMapper _mapper;
        private readonly IConfiguration _configuration;
       

        public StaticService(IRepositoryManager repository, IMapper mapper, IConfiguration configuration)
        {
            _repository = repository;
            _mapper = mapper;
            _configuration = configuration;
        }

        #region Task Priorities
        public async Task<ServiceResponse<IEnumerable<TaskPriorityDto>>> GetAllTaskPrioritiesAsync(bool trackChanges)
        {
            try
            {
                var taskPriorities = await _repository.TaskPriorityRepository.GetAllTaskPriority(trackChanges);
                var taskPrioritiesDto = _mapper.Map<IEnumerable<TaskPriorityDto>>(taskPriorities);
                return new ServiceResponse<IEnumerable<TaskPriorityDto>>(true, "تم جلب الأولويات بنجاح", taskPrioritiesDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskPriorityDto>>(false, $"حدث خطأ: {ex.Message}", null);
            }
        }
        #endregion

        #region Task Categories
        public async Task<ServiceResponse<IEnumerable<TaskCategoryDto>>> GetAllTaskCategoriesAsync(bool trackChanges)
        {
            try
            {
                var taskCategories = await _repository.TaskCategoryRepository.GetAllTaskCategory(trackChanges);
                var taskCategoriesDto = _mapper.Map<IEnumerable<TaskCategoryDto>>(taskCategories);
                return new ServiceResponse<IEnumerable<TaskCategoryDto>>(true, "تم جلب الفئات بنجاح", taskCategoriesDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<TaskCategoryDto>>(false, $"حدث خطأ: {ex.Message}", null);
            }
        }
        #endregion

        #region Statuses
        public async Task<ServiceResponse<IEnumerable<StatusDto>>> GetAllStatusesAsync(bool trackChanges)
        {
            try
            {
                var statuses = await _repository.StatusRepository.GetAllStutus(trackChanges);
                var statusesDto = _mapper.Map<IEnumerable<StatusDto>>(statuses);
                return new ServiceResponse<IEnumerable<StatusDto>>(true, "تم جلب الحالات بنجاح", statusesDto);
            }
            catch (Exception ex)
            {
                return new ServiceResponse<IEnumerable<StatusDto>>(false, $"حدث خطأ: {ex.Message}", null);
            }
        }
        #endregion

    }
}
