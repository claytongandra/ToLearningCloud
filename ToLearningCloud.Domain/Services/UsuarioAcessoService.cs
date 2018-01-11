using ToLearningCloud.Domain.Entities;
using ToLearningCloud.Domain.Interfaces.Repositories;
using ToLearningCloud.Domain.Interfaces.Services;

namespace ToLearningCloud.Domain.Services
{
    public class UsuarioAcessoService : IUsuarioAcessoService
    {
        //////private readonly IUsuarioAcessoRepository _usuarioAcessoRepository;

        //////public UsuarioAcessoService(IUsuarioAcessoRepository usuarioAcessoRepository)
        //////{
        //////    _usuarioAcessoRepository = usuarioAcessoRepository;
        //////}


        //////public UsuarioAcesso GetAcessoByUsuarioId(string id)
        //////{
        //////    return _usuarioAcessoRepository.GetAcessoByUsuarioId(id);
        //////}

        //////public string GetLoginByEmailOrUser(string login)
        //////{
        //////    return _usuarioAcessoRepository.GetLoginByEmailOrUser(login);
        //////}
    }
}
