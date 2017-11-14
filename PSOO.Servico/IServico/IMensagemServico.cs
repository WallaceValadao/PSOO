using PSOO.Dominio;
using System.Collections.Generic;

namespace PSOO.Servico.IServico
{
    public interface IMensagemServico
    {
        void AdicionaMensagem(Mensagem mensagem);
        List<Mensagem> ListaNovasMengens(int idUsuario);
    }
}
