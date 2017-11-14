using System;
using System.Collections.Generic;

namespace PSOO.Dominio
{
    public class Mensagem : IEntidade
    {
        public int Id { get; set; }
        public Usuario Iniciador { get; set; }
        public ICollection<Contato> listaContatos { get; set; }
        public string Localizacao { get; set; }
        public DateTime DataHora { get; set; }
        public string Texto { get; set; }
    }
}
