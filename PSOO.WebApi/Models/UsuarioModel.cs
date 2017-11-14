using PSOO.Dominio;
using System.Collections.Generic;

namespace PSOO.WebApi.Models
{
    public class UsuarioModel
    {
        public string Nome { get; private set; }
        public byte[] Foto { get; private set; }
        public List<ContatoModel> Contatos { get; private set; }

        public UsuarioModel(Usuario usuario)
        {
            this.Nome = usuario.Nome;
            this.Foto = usuario.Foto;

            this.Contatos = new List<ContatoModel>();

            usuario.Contatos?.ForEach(delegate (Contato item)
            {
                Contatos.Add(new ContatoModel(item.Id, item.Nome));
            });
        }
    }
}