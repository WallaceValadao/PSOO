using System;
using System.Collections.Generic;

namespace PSOO.Dominio
{
    public class Usuario : IEntidade
    {
        public int Id { get; set; }
        public string Nome { get; set; }
        public DateTime DataNascimento { get; set; }
        public string Localizacao { get; set; }
        public byte[] Foto { get; set; }
        public string Status { get; set; }
        public int Numero { get; set; }

        public string Login { get; set; }
        public string Senha { get; set; }
        
        public List<Contato> Contatos { get; set; }
        public List<Perfil> Perfis { get; set; }
    }
}
