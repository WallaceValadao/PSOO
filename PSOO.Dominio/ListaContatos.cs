using System.Collections.Generic;

namespace PSOO.Dominio
{
    public class ListaContatos
    {
        public int Id { get; set; }
        public ICollection<Perfil> Perfis { get; set; }
    }
}
