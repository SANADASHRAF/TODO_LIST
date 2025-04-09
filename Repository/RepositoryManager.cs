using Contract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Repository
{
    public class RepositoryManager :IRepositoryManager
    {
        private readonly RepositoryContext _repositoryContext;
        private readonly Lazy<IUserRepository> _userRepository;
        private readonly Lazy<IEmailVerificationsRepository> _emailVerifications;
        private readonly Lazy<IStatusRepository> _statusRepository;
        private readonly Lazy<ITaskCategoryRepository> _taskCategoryRepository;
        private readonly Lazy<ITaskPriorityRepository> _taskPriorityRepository;
        private readonly Lazy<ITasksRepository> _tasksRepository;
   

        public RepositoryManager(RepositoryContext repositoryContext)
        {
            _repositoryContext = repositoryContext;
            _userRepository = new Lazy<IUserRepository>(() => new UserRepository(repositoryContext));
            _emailVerifications = new Lazy<IEmailVerificationsRepository>(() => new EmailVerificationsRepository(repositoryContext));
            _statusRepository = new Lazy<IStatusRepository>(() => new StatusRepository(repositoryContext));
            _taskCategoryRepository = new Lazy<ITaskCategoryRepository>(() => new TaskCategoryRepository(repositoryContext));
            _taskPriorityRepository = new Lazy<ITaskPriorityRepository>(() => new TaskPriorityRepository(repositoryContext));
            _tasksRepository = new Lazy<ITasksRepository>(() => new TasksRepository(repositoryContext));
            
        }

        public IUserRepository User => _userRepository.Value;
        public IEmailVerificationsRepository EmailVerifications => _emailVerifications.Value;
        public IStatusRepository StatusRepository => _statusRepository.Value;
        public ITaskCategoryRepository TaskCategoryRepository => _taskCategoryRepository.Value;
        public ITaskPriorityRepository TaskPriorityRepository => _taskPriorityRepository.Value;
        public ITasksRepository TasksRepository => _tasksRepository.Value;
       

        public void Save() => _repositoryContext.SaveChanges();
    }
}
