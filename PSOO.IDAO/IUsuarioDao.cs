using PSOO.Dominio;

namespace PSOO.IDAO
{
    public interface IUsuarioDao : IDAO<Usuario>
    {
        Usuario BuscarPorLogin(string login);
    }
}
