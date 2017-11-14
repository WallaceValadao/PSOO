using PSOO.Dominio;
using PSOO.IDAO;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.DAO
{
    public class MensagemDao : DAO<Mensagem>, IMensagemDao
    {

        public MensagemDao(IConexao Conexao) : base(Conexao)
        {
        }
    }
}
