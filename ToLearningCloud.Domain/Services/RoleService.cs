using System.Collections.Generic;
using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class RoleService : ServiceBase<Role>, IRoleService
    {
        //////private readonly IRoleRepository _roleRepository;

        //////public RoleService(IRoleRepository roleRepository)
        //////     : base(roleRepository)
        //////{
        //////    _roleRepository = roleRepository;
        //////}

        //////public bool RoleExists(string nomeRole)
        //////{
        //////    return _roleRepository.RoleExists(nomeRole);
        //////}

        //////public IEnumerable<Role> GetByName(string nomeRole)
        //////{
        //////    return _roleRepository.GetByName(nomeRole);
        //////}


        ////////public IEnumerable<Role> GetAllRoles()
        ////////{
        ////////   return _roleRepository.GetAllRoles();
        ////////}

        ////////public Role FindById(string id)
        ////////{
        ////////    return _roleRepository.FindById(id);
        ////////}

        ////////public void CreateRole(Role objRole)
        ////////{
        ////////    _roleRepository.CreateRole(objRole);
        ////////}
    }
}
