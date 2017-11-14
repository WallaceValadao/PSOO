using Ninject;
using PSOO.Servico.IServico;
using PSOO.WebApi.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace PSOO.WebApi.Controllers
{
    public class UsuarioController : ApiController
    {
        //Injeção de dependência
        [Inject]
        public IUsuarioServico usuarioServico { private get; set; }

        [Inject]
        public IPerfilServico perfilServico { private get; set; }

        public HttpResponseMessage Get()
        {
            var lista = new List<UsuarioModel>();

            foreach (var item in usuarioServico.Listar())
                lista.Add(new UsuarioModel(item));

            return lista.RetornoOK();
        }

        public HttpResponseMessage Get(int id)
        {
            var user = usuarioServico.BuscaUsuario(id);
            
            return new UsuarioModel(user).RetornoOK();
        }
        
        public HttpResponseMessage Post(UsuarioInserirModel user)
        {
            if (!ModelState.IsValid)
                return "Dados invalidos".Retorno(HttpStatusCode.BadRequest);

            var modelo = user.getUsuario();

            usuarioServico.InsereUsuario(modelo);

            return modelo.Id.ToString().Retorno();
        }

        public HttpResponseMessage Delete(int id)
        {
            var modelo = usuarioServico.BuscaUsuario(id);

            if (modelo == null)
                return "Usuário não encontrado.".Retorno(HttpStatusCode.BadRequest);

            usuarioServico.Deletar(modelo);

            return string.Empty.Retorno();
        }


            //+ UsuarioController(user : UsuarioServico) : void
            //+ setNovoContato(usuario : UsuarioModel, perfis : List<Perfil>) : void
            //+ AtualizaPerfil(perfils : List<Perfil>) : void
    }
}
