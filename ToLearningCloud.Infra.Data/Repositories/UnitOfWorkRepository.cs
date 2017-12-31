using System.Data.Entity;
using ToLearningCloud.Domain.Interfaces.Repositories;
using Microsoft.Practices.ServiceLocation;
using ToLearningCloud.Infra.Data.EntityFramework;
using ToLearningCloud.Infra.Data.Context;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class UnitOfWorkRepository : IUnitOfWorkRepository
    {
        private DbContext _context;

        public void BeginTransactionUoW()
        {
            var contextManager = ServiceLocator.Current.GetInstance<ContextManager<ToLearningCloudContext>>();
            _context = contextManager.GetContext;

        }

        public void CommitUoW()
        {
            _context.SaveChanges();
        }
    }

}
