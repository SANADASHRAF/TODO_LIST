using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class Tasks
    {
        [Key]
        public int Id { get; set; } 
        public string Title { get; set; } 
        public string Description { get; set; } 
        public DateTime StartDate { get; set; } =DateTime.UtcNow;
        public DateTime? EndDate { get; set; } 


        [ForeignKey("TaskStatus")]
        public int TaskStatusId { get; set; }
        public virtual Status TaskStatus { get; set; } 


        [ForeignKey("TaskCategory")]
        public int TaskCategoryId { get; set; } 
        public virtual TaskCategory TaskCategory { get; set; } 


        [ForeignKey("User")]
        public int UserId { get; set; } 
        public virtual User User { get; set; } 


        [ForeignKey("TaskPriority")]
        public int TaskPriorityId { get; set; }
        public virtual TaskPriority TaskPriority { get; set; } 
        
    }
}
