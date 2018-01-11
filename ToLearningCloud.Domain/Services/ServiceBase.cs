using System;
using System.Collections.Generic;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class ServiceBase<TEntity> : IDisposable, IServiceBase<TEntity> where TEntity : class
    {
        //////private readonly IRepositoryBase<TEntity> _repository;

        //////public ServiceBase(IRepositoryBase<TEntity> repository)
        //////{
        //////    _repository = repository;
        //////}

        //////public void Add(TEntity obj)
        //////{
        //////    _repository.Add(obj);
        //////}

        //////public TEntity GetById(int id)
        //////{
        //////    return _repository.GetById(id);
        //////}

        //////public TEntity GetByIdGuide(string id)
        //////{
        //////    return _repository.GetByIdGuide(id);
        //////}

        //////public IEnumerable<TEntity> GetAll()
        //////{
        //////    return _repository.GetAll();
        //////}

        //////public void Update(TEntity obj)
        //////{
        //////    _repository.Update(obj);
        //////}

        //////public void Remove(TEntity obj)
        //////{
        //////    _repository.Remove(obj);
        //////}

        public void Dispose()
        {
            //////_repository.Dispose();
        }


    }
}

