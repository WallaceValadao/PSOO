using PSOO.DAO.DataBase;
using PSOO.Dominio;

namespace PSOO.DAO.Mapeamento
{
    public class ContatoMap : GenericMap<Contato>
    {
        public ContatoMap()
        {
            Tabela("T_CONTATO");
            Id(x => x.Id, "ID_CONTADO", "");
            Map(x => x.Nome, "DSC_NOME", "");
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
