using Ninject;
using PSOO.Dominio;
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
    public class MensagemController : ApiController
    {
        [Inject]
        public IMensagemServico mensagemServico { private get; set; }

        public HttpResponseMessage Get(int idUsuario)
        {
            var mensagens = mensagemServico.ListaNovasMengens(idUsuario);

            var lista = new List<MensagemModel>();

            mensagens.ForEach(delegate (Mensagem item)
            {
                lista.Add(new MensagemModel(item));
            });

            return lista.RetornoOK();
        }
        
        //+ setMensagem(mensagem : String, idUsuario : int, idContato : int) : void
    }
}
