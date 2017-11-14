using PSOO.Dominio;
using PSOO.IDAO;
using PSOO.Servico.IServico;
using System;
using System.Collections.Generic;

namespace PSOO.Servico
{
    public sealed class ContatoServico : IContatoServico
    {
        private readonly IContatoDao dao;

        public ContatoServico(IContatoDao dao)
        {
            this.dao = dao;
        }

        public void AdicionaContato(Contato contato)
        {
            dao.Salvar(contato);
        }

        public void RemoveContato(Contato contato)
        {
            dao.Deletar(contato);
        }
          
        public List<Contato> ListaContatosPorUsuario(int idUsuario) => dao.ListaContatosPorUsuario(idUsuario);
    }
}
