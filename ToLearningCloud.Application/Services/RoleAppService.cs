using System;
using System.Collections.Generic;
using ToLearningCloud.Application.Interfaces;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Application.Services
{
    public class RoleAppService : AppServiceBase<Role>, IRoleAppService
    {
        //////private readonly IRoleService _roleService;
        //////private readonly IUsuarioRoleAppService _usuarioRoleApp;

        //////public RoleAppService(IRoleService roleService, IUsuarioRoleAppService usuarioRoleApp)
        //////     : base(roleService)
        //////{
        //////    _roleService = roleService;
        //////    _usuarioRoleApp = usuarioRoleApp;
        //////}

        //////public bool RoleExists(string nomeRole)
        //////{
        //////    return _roleService.RoleExists(nomeRole);
        //////}

        //////public IEnumerable<Role> GetAllRoles()
        //////{
        //////    return _roleService.GetAll();
        //////}

        //////public Role GetRoleById(string id)
        //////{
        //////    return _roleService.GetByIdGuide(id);
        //////}

        //////public void CreateRole(Role objRole)
        //////{
        //////    if (RoleExists(objRole.Role_Nome))
        //////        throw new Exception("O papel \"" + objRole.Role_Nome + "\" já existe.");

        //////    BeginTransactionUoW();
        //////    _roleService.Add(objRole);
        //////    ComitUoW();
        //////}

        //////public IEnumerable<Role> GetRoleByName(string nomeRole)
        //////{
        //////    return _roleService.GetByName(nomeRole);
        //////}

        //////public void UpdateRole(Role objRole)
        //////{
        //////    BeginTransactionUoW();
        //////    _roleService.Update(objRole);
        //////    ComitUoW();
        //////}

        //////public void DeleteRole(Role objRole)
        //////{
        //////    BeginTransactionUoW();
        //////    // objRole.Role_UsuariosRoles = (ICollection<UsuarioRole>)_usuarioRoleApp.GetRoleUsersByRoleId(objRole.Role_Id);
        //////    _usuarioRoleApp.DeleteAllRoleUsersByIdRole(objRole.Role_Id);
        //////    _roleService.Remove(objRole);
        //////    ComitUoW();
        //////}
    }
}
