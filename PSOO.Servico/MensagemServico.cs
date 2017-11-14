using PSOO.Dominio;
using PSOO.IDAO;
using PSOO.Servico.IServico;
using System;
using System.Collections.Generic;

namespace PSOO.Servico
{
    public sealed class MensagemServico : IMensagemServico
    {
        private readonly IMensagemDao dao;

        public MensagemServico(IMensagemDao dao)
        {
            this.dao = dao;
        }

        public void AdicionaMensagem(Mensagem mensagem)
        {
            dao.Salvar(mensagem);
        }

        public List<Mensagem> ListaNovasMengens(int idUsuario)
        {
            throw new NotImplementedException();
        }
    }
}
