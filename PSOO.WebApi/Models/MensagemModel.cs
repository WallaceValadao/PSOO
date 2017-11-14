using PSOO.Dominio;
using System;

namespace PSOO.WebApi.Models
{
    public class MensagemModel
    {
        public string Mensagem { get; private set; }
        public DateTime Data { get; private set; }
        public int Remetente { get; private set; }

        public MensagemModel(Mensagem mensagem)
        {
            this.Mensagem = mensagem.Texto;
            this.Data = mensagem.DataHora;
            this.Remetente = mensagem.Iniciador.Id;
        }
    }

    public class MensagemPostModel
    {
        public string Mensagem { get; set; }
        public int IdUsuario { get; set; }
        public int IdContato { get; set; }
    }
}