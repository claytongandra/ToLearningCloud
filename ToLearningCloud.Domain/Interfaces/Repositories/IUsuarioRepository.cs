using System;
using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;

namespace ToLearningCloud.Domain.Interfaces.Repositories
{
    public interface IUsuarioRepository : IDisposable
    {
        Usuario ObterPorId(string id);
        IEnumerable<Usuario> ObterTodos();
        void DesativarLock(string id);
    }
}