using PSOO.Dominio;
using System.Collections;
using System.Collections.Generic;

namespace PSOO.Servico.IServico
{
    public interface IUsuarioServico
    {
        void InsereUsuario(Usuario usuario);
        void AtualizaUsuario(Usuario usuario);
        void Deletar(Usuario usuario);
        bool VerificarLoginSenha(string login, string senha);
        Usuario BuscaUsuario(int idUsuario);
        ICollection<Usuario> Listar();
    }
}
