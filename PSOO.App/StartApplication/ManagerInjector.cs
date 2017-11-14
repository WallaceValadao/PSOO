using PSOO.DAO;
using PSOO.IDAO;
using PSOO.Servico;
using PSOO.Servico.IServico;

namespace PSOO.App
{
    public class ManagerInjector
    {
        private static ManagerInjector manager { get; set; }

        private IConexao Dao { get; set; }

        private IContatoServico contatoServico { get; set; }
        private IUsuarioServico usuarioServico { get; set; }

        private IConexao getConexao()
        {
            if (this.Dao == null)
                this.Dao = new Configuracao();

            return this.Dao;
        }

        public IUsuarioServico UsuarioServico()
        {
            if (usuarioServico == null)
                usuarioServico = new UsuarioServico(new UsuarioDao(getConexao()));

            return usuarioServico;
        }

        internal ManagerInjector()
        {

        }

        public static ManagerInjector get()
        {
            if (manager == null)
                manager = new ManagerInjector();

            return manager;
        }
    }
}