﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Entities.Models
{
    public class TaskCategory
    {
        [Key]
        public int Id { get; set; } 
        public string Name { get; set; } 
        public virtual ICollection<Tasks> Tasks { get; set; } = new List<Tasks>();
    }
}
