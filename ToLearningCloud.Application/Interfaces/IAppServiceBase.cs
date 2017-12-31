using System.Collections.Generic;

namespace ToLearningCloud.Application.Interfaces
{
    public interface IAppServiceBase<TEntity> where TEntity : class
    {
        TEntity GetById(int id);
        TEntity GetByIdGuide(string id);
        IEnumerable<TEntity> GetAll();
        void BeginTransactionUoW();
        void ComitUoW();
        void Dispose();
    }
}
