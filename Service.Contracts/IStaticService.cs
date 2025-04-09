using Shared.DataTransferObjects;
using Shared;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IStaticService
    {
        Task<ServiceResponse<IEnumerable<TaskPriorityDto>>> GetAllTaskPrioritiesAsync(bool trackChanges);
        Task<ServiceResponse<IEnumerable<TaskCategoryDto>>> GetAllTaskCategoriesAsync(bool trackChanges);
        Task<ServiceResponse<IEnumerable<StatusDto>>> GetAllStatusesAsync(bool trackChanges);
    }
}
