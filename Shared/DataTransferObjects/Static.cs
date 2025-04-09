using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Shared.DataTransferObjects
{

    public class TaskPriorityDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class TaskCategoryDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

    public class StatusDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
    }

}
