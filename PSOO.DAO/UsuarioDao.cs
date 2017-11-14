using PSOO.Dominio;
using PSOO.IDAO;
using System.Linq;

namespace PSOO.DAO
{
    public class UsuarioDao : DAO<Usuario>, IUsuarioDao
    {
        public UsuarioDao(IConexao Conexao) : base(Conexao)
        {
        }

        public Usuario BuscarPorLogin(string login)
        {
            return Dados.listaUsuario.Where(x => x.Login == login).FirstOrDefault();
        }
    }
}
