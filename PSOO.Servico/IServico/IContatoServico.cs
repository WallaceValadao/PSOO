using PSOO.Dominio;
using System.Collections.Generic;

namespace PSOO.Servico.IServico
{
    public interface IContatoServico
    {
        void AdicionaContato(Contato contato);
        void RemoveContato(Contato contato);
        List<Contato> ListaContatosPorUsuario(int idUsuario);
    }
}
