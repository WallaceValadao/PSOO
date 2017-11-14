using PSOO.Dominio;
using System.Collections.Generic;

namespace PSOO.IDAO
{
    public interface IContatoDao : IDAO<Contato>
    {
        List<Contato> ListaContatosPorUsuario(int idUsuario);
    }
}
