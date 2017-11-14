using PSOO.Dominio;
using PSOO.IDAO;
using PSOO.Servico.IServico;
using System;
using System.Collections.Generic;

namespace PSOO.Servico
{
    public sealed class UsuarioServico : IUsuarioServico
    {
        private readonly IUsuarioDao dao;

        public UsuarioServico(IUsuarioDao dao)
        {
            this.dao = dao;
        }

        public void AtualizaUsuario(Usuario usuario)
        {
            throw new NotImplementedException();
        }

        public void InsereUsuario(Usuario usuario)
        {
            dao.Salvar(usuario);
        }

        public void Deletar(Usuario usuario)
        {
            this.dao.Deletar(usuario);
        }

        public bool VerificarLoginSenha(string login, string senha)
        {
            var user = dao.BuscarPorLogin(login);

            return user.Senha == senha;
        }

        public Usuario BuscaUsuario(int idUsuario) => dao.BuscarPorId(idUsuario);

        public ICollection<Usuario> Listar() => dao.Listar();
    }
}
