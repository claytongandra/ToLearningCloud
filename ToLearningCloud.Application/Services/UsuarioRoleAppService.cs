using System.Collections.Generic;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Application.Services
{
    public class UsuarioRoleAppService : AppServiceBase<UsuarioRole>, IUsuarioRoleAppService
    {

        //////private readonly IUsuarioRoleService _usuarioRoleService;

        //////public UsuarioRoleAppService(IUsuarioRoleService usuarioRoleService)
        //////     : base(usuarioRoleService)
        //////{
        //////    _usuarioRoleService = usuarioRoleService;
        //////}

        //////public void DeleteAllRoleUsersByIdRole(string idRole)
        //////{
        //////    _usuarioRoleService.RemoveAllRoleUsersByRoleId(idRole);
        //////}

        //////public IEnumerable<UsuarioRole> GetRoleUsersByRoleId(string idRole)
        //////{
        //////    return _usuarioRoleService.GetRoleUsersByRoleId(idRole);
        //////}
    }
}
