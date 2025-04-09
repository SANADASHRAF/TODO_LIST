using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{
    public class TaskDto
    {
        public int Id { get; set; }
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime StartDate { get; set; }
        public DateTime? EndDate { get; set; }
        public int TaskStatusId { get; set; }
        public string TaskStatusName { get; set; }
        public int TaskCategoryId { get; set; }
        public string TaskCategoryName { get; set; }
        public int UserId { get; set; }
        public int TaskPriorityId { get; set; }
        public string TaskPriorityName { get; set; }
    }

    public class CreateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskCategoryId { get; set; }
        public int UserId { get; set; }
        public int TaskPriorityId { get; set; }
    }

    public class UpdateTaskDto
    {
        public string Title { get; set; }
        public string Description { get; set; }
        public DateTime? EndDate { get; set; }
        public int TaskStatusId { get; set; }
        public int TaskCategoryId { get; set; }
        public int TaskPriorityId { get; set; }
    }


}
