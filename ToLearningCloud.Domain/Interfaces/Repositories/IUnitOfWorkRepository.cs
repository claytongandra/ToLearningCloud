using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ToLearningCloud.Domain.Interfaces.Repositories
{
    public interface IUnitOfWorkRepository
    {
        void BeginTransactionUoW();
        void CommitUoW();
    }
}
