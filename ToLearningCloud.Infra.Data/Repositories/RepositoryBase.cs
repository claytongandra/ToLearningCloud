using CommonServiceLocator.SimpleInjectorAdapter;
using Microsoft.Practices.ServiceLocation;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Infra.Data.Context;
using ToLearningCloud.Infra.Data.EntityFramework;

namespace ToLearningCloud.Infra.Data.Repositories
{
    public class RepositoryBase<TEntity> : IDisposable, IRepositoryBase<TEntity> where TEntity : class

    {
        //////protected DbContext ContextDB { get; private set; }

        //////public RepositoryBase()
        //////{
        //////    var contextManager = ServiceLocator.Current.GetInstance<ContextManager<ToLearningCloudContext>>();
        //////    ContextDB = contextManager.GetContext;
        //////}


        //////public void Add(TEntity obj)
        //////{
        //////    ContextDB.Set<TEntity>().Add(obj);
        //////}

        //////public IEnumerable<TEntity> GetAll()
        //////{
        //////    return ContextDB.Set<TEntity>().ToList(); // verificar o AsNoTracking().ToList();
        //////}

        //////public TEntity GetById(int id)
        //////{
        //////    return ContextDB.Set<TEntity>().Find(id);
        //////}

        //////public TEntity GetByIdGuide(string id)
        //////{
        //////    return ContextDB.Set<TEntity>().Find(id);
        //////}

        //////public void Remove(TEntity obj)
        //////{
        //////    ContextDB.Set<TEntity>().Remove(obj);
        //////}

        //////public void Update(TEntity obj)
        //////{
        //////    ContextDB.Entry(obj).State = EntityState.Modified;
        //////}

        ////////public void RemoveById(int id)
        ////////{
        ////////    var obj = GetById(id);
        ////////    Remove(obj);
        ////////}

        public void Dispose()
        {
            //////    ContextDB.Dispose();
        }

}
}
