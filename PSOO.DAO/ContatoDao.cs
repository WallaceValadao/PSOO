using System.Collections.Generic;
using PSOO.Dominio;
using PSOO.IDAO;
using System.Linq;

namespace PSOO.DAO
{
    public class ContatoDao : DAO<Contato>, IContatoDao
    {
        public ContatoDao(IConexao Conexao) : base(Conexao) { }

        public List<Contato> ListaContatosPorUsuario(int idUsuario)
        {
            return Dados.listaUsuario.Where(x => x.Id == idUsuario).FirstOrDefault().Contatos;
        }
    }
}
