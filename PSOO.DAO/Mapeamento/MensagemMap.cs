using PSOO.DAO.DataBase;
using PSOO.Dominio;

namespace PSOO.DAO.Mapeamento
{
    public class MensagemMap : GenericMap<Mensagem>
    {
        public MensagemMap()
        {
            Tabela("T_MENSAGEM");
            Id(x => x.Id, "ID_MENSAGEM", "long");
            Map(x => x.Texto, "DSC_MENSAGEM", "string");
            //Map(x => x.DataNascimento, "dat_nascimento");
            //Map(x => x.Localizacao, "localizacao");
            //Map(x => x.Foto, "foto");
            //Map(x => x.Status, "status");
            //Map(x => x.Numero, "numero");
            //Map(x => x.Login, "login");
            //Map(x => x.Senha, "senha");
        }
    }
}
