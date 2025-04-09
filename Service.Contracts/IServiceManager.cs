using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Service.Contracts
{
    public interface IServiceManager
    {
        IUserService UserService { get; }
        IEmailService EmailService { get; }
        IStaticService StaticService { get; }
        ITaskService TaskService { get; }
    }
}
