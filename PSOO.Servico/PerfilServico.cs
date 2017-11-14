using PSOO.Dominio;
using PSOO.IDAO;
using PSOO.Servico.IServico;
using System;

namespace PSOO.Servico
{
    public sealed class PerfilServico : IPerfilServico
    {
        private readonly IPerfilDao dao;

        public PerfilServico(IPerfilDao dao)
        {
            this.dao = dao;
        }

        public void AdicionaPerfil(Perfil perfil)
        {
            throw new NotImplementedException();
        }

        public void AlteraPerfil(Perfil perfil)
        {
            throw new NotImplementedException();
        }
    }
}
