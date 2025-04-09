using Entities.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Contract
{
    public interface IStatusRepository
    {
        Task<IEnumerable<Status>> GetAllStutus(bool trackChanges);
    }
}
