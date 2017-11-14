using Newtonsoft.Json;
using PSOO.Dominio;
using System;
using System.ComponentModel.DataAnnotations;

namespace PSOO.WebApi.Models
{
    public class UsuarioInserirModel
    {
        [Required]
        [JsonProperty("nome")]
        public string Nome { get; set; }

        [Required]
        [JsonProperty("dataNascimento")]
        public DateTime DataNascimento { get; set; }

        [JsonProperty("localizacao")]
        public string Localizacao { get; set; }

        [JsonProperty("foto")]
        public byte[] Foto { get; set; }

        [JsonProperty("status")]
        public string Status { get; set; }

        [Required]
        [JsonProperty("numero")]
        public int Numero { get; set; }

        [Required]
        [JsonProperty("login")]
        public string Login { get; set; }

        [Required]
        [JsonProperty("senha")]
        public string Senha { get; set; }

        private Usuario modelo { get; set; }

        public Usuario getUsuario()
        {
            if(modelo == null)
                modelo = new Usuario
                {
                    Nome = this.Nome,
                    Foto = this.Foto,
                    Localizacao = this.Localizacao,
                    DataNascimento = this.DataNascimento,
                    Status = this.Status,
                    Numero = this.Numero,
                    Login = this.Login,
                    Senha = this.Senha
                };

            return this.modelo;
        }
    }
}