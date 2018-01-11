using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class UsuarioRoleService : ServiceBase<UsuarioRole>, IUsuarioRoleService
    {

        //////private readonly IUsuarioRoleRepository _usuarioRoleRepository;

        //////public UsuarioRoleService(IUsuarioRoleRepository usuarioRoleRepository)
        //////     : base(usuarioRoleRepository)
        //////{
        //////    _usuarioRoleRepository = usuarioRoleRepository;
        //////}

        //////public void RemoveAllRoleUsersByRoleId(string idRole)
        //////{
        //////    _usuarioRoleRepository.RemoveAllRoleUsersByRoleId(idRole);
        //////}

        //////public IEnumerable<UsuarioRole> GetRoleUsersByRoleId(string idRole)
        //////{
        //////    return _usuarioRoleRepository.GetRoleUsersByRoleId(idRole);
        //////}

    }
}
