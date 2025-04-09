using AutoMapper;
using Contract;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;
using Service.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service
{
    public class ServiceManager :IServiceManager
    {
        private readonly Lazy<IUserService> _userService;
        private readonly Lazy<IEmailService> _emailService;
        private readonly Lazy<IStaticService> _staticService;
        private readonly Lazy<ITaskService> _taskService;
        public ServiceManager(IRepositoryManager repositoryManager, IMapper mapper, IConfiguration configuration)
        {
            _emailService = new Lazy<IEmailService>(() => new EmailService());
            _userService = new Lazy<IUserService>(() => new UserService(repositoryManager, mapper, configuration, _emailService.Value));
            _staticService = new Lazy<IStaticService>(() => new StaticService(repositoryManager, mapper, configuration));
            _taskService = new Lazy<ITaskService>(() => new TaskService(repositoryManager, mapper));
        }
        public IUserService UserService => _userService.Value;
        public IEmailService EmailService => _emailService.Value;
        public IStaticService StaticService => _staticService.Value;
        public ITaskService TaskService => _taskService.Value;
    }
}
