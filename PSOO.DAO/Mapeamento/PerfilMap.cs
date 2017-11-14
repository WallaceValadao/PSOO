using PSOO.DAO.DataBase;
using PSOO.Dominio;

namespace PSOO.DAO.Mapeamento
{
    public class PerfilMap : GenericMap<Perfil>
    {
        public PerfilMap()
        {
            Tabela("T_PERFIL");
            Id(x => x.Id, "ID_PERFIL", "");
            Map(x => x.Descricao, "DSC_NOME", "");
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
