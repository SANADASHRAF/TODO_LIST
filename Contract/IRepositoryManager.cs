using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IRepositoryManager
    {
        IUserRepository User { get; }
        IEmailVerificationsRepository EmailVerifications { get; }
        IStatusRepository StatusRepository { get; }
        ITaskCategoryRepository TaskCategoryRepository { get; }
        ITaskPriorityRepository TaskPriorityRepository { get; }
        ITasksRepository TasksRepository { get; }
        void Save();
    }
}
