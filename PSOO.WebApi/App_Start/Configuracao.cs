using PSOO.IDAO;
using System.Configuration;
using PSOO.Dominio.Enumeradores;
using System;

namespace PSOO.WebApi.App_Start
{
    public class Configuracao : IConexao
    {
        public string ConnectionString { get; }

        public string DefaultSchemaDB { get; }

        public string NomeBanco { get; }

        public string NameSpaceMap { get; }

        public TipoBanco TipoBanco { get; }

        public Configuracao()
        {
            this.DefaultSchemaDB =  ConfigurationManager.AppSettings["defaultSchema"];
            this.ConnectionString = ConfigurationManager.ConnectionStrings["conexao"].ConnectionString;
            this.NameSpaceMap = "PSOO.DAO.Mapeamento";
            this.TipoBanco = TipoBanco.MySQL;
        }
    }
}