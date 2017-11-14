using PSOO.Dominio;
using System.Collections.Generic;

namespace PSOO.IDAO
{
    public interface IDAO<T> where T : class, IEntidade
    {
        void Salvar(T entidade);
        void Deletar(T entidade);
        T BuscarPorId(int id);
        List<T> Listar();
    }
}
