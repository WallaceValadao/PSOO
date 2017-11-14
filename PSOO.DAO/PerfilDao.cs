using PSOO.Dominio;
using PSOO.IDAO;

namespace PSOO.DAO
{
    public class PerfilDao : DAO<Perfil>, IPerfilDao
    {
        public PerfilDao(IConexao Conexao) : base(Conexao)
        {
        }
    }
}
