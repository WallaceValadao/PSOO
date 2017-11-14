using PSOO.Dominio;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PSOO.DAO
{
    /// <summary>
    /// Classe static para teste.
    /// </summary>
    public static class Dados
    {
        public  static List<Usuario> listaUsuario { get; set; }
        public static List<Perfil> listaPerfil { get; set; }
        public static List<Contato> listaContato { get; set; }
        public static List<Mensagem> listaMensagem { get; set; }

        public static void Gerar()
        {
            if (listaUsuario == null)
                gerarDados();
        }

        private static void gerarDados()
        {
            var user1 = new Usuario { Id = 1, Nome = "Wallace", DataNascimento = DateTime.Now, Login = "wallace", Senha = "123", Status = "Ativo", Numero = 71705782, Localizacao = "4534535156156156" };
            var user2 = new Usuario { Id = 1, Nome = "Wagner", DataNascimento = DateTime.Now.AddDays(-7), Login = "wagner", Senha = "123", Status = "Ativo", Numero = 84856165, Localizacao = "35434554156156156" };
            var user3 = new Usuario { Id = 1, Nome = "Teste", DataNascimento = DateTime.Now.AddDays(-6), Login = "salve", Senha = "123", Status = "Ativo", Numero = 498489, Localizacao = "35434535156156156" };
            var user4 = new Usuario { Id = 1, Nome = "MeuNome", DataNascimento = DateTime.Now.AddDays(-44), Login = "teste", Senha = "123", Status = "Ativo", Numero = 84895782, Localizacao = "5435414534534556156156" };
            var user5 = new Usuario { Id = 1, Nome = "Teste", DataNascimento = DateTime.Now.AddDays(-23), Login = "teste2", Senha = "123", Status = "Ativo", Numero = 25156, Localizacao = "54378387387873" };
            
            var perfil1 = new Perfil { Descricao = "Musica", Id = 1, Tipo = "Musica" };
            var perfil2 = new Perfil { Descricao = "Jogos", Id = 2, Tipo = "Jogos" };
            var perfil3 = new Perfil { Descricao = "Filme", Id = 3, Tipo = "Filme" };
            var perfil4 = new Perfil { Descricao = "Esporte", Id = 4, Tipo = "Esporte" };
            var perfil5 = new Perfil { Descricao = "Radical", Id = 5, Tipo = "Radical" };

            var contato1 = new Contato { Id = 1, Nome = "Fulana", Numero = 165156 };
            var contato2 = new Contato { Id = 2, Nome = "Fulano", Numero = 165156 };
            var contato3 = new Contato { Id = 3, Nome = "Mae", Numero = 165156 };
            var contato4 = new Contato { Id = 4, Nome = "Wallace", Numero = 165156 };
            var contato5 = new Contato { Id = 5, Nome = "Wagner", Numero = 165156 };
            var contato6 = new Contato { Id = 6, Nome = "Professor", Numero = 165156 };
            var contato7 = new Contato { Id = 7, Nome = "teste", Numero = 165156 };
            var contato8 = new Contato { Id = 8, Nome = "Sei la", Numero = 165156 };
            var contato9 = new Contato { Id = 9, Nome = "Faculdade", Numero = 165156 };
            var contato10 = new Contato { Id = 10, Nome = "Teste2", Numero = 165156 };
            var contato11 = new Contato { Id = 11, Nome = "Casa", Numero = 165156 };
            var contato12 = new Contato { Id = 12, Nome = "TEste", Numero = 165156 };
            var contato13 = new Contato { Id = 13, Nome = "Ola", Numero = 165156 };

            user1.Contatos = new List<Contato>();
            user2.Contatos = new List<Contato>();
            user3.Contatos = new List<Contato>();
            user4.Contatos = new List<Contato>();
            user5.Contatos = new List<Contato>();

            user1.Contatos.Add(contato1);
            user1.Contatos.Add(contato10);
            user1.Contatos.Add(contato3);
            user1.Contatos.Add(contato5);
            user1.Contatos.Add(contato6);
            user1.Contatos.Add(contato7);
            user1.Contatos.Add(contato8);

            user2.Contatos.Add(contato1);
            user2.Contatos.Add(contato7);
            user2.Contatos.Add(contato5);
            user2.Contatos.Add(contato2);
            user2.Contatos.Add(contato7);
            user2.Contatos.Add(contato9);
            user2.Contatos.Add(contato13);

            user3.Contatos.Add(contato4);
            user3.Contatos.Add(contato3);
            user3.Contatos.Add(contato12);
            user3.Contatos.Add(contato11);

            user4.Contatos.Add(contato5);
            user4.Contatos.Add(contato3);
            user4.Contatos.Add(contato6);
            user4.Contatos.Add(contato8);

            user5.Contatos.Add(contato4);
            user5.Contatos.Add(contato13);
            user5.Contatos.Add(contato9);
            user5.Contatos.Add(contato13);

            var listaCont1 = new List<Contato>();
            listaCont1.Add(contato4);

            var listaCont2 = new List<Contato>();
            listaCont2.Add(contato5);

            var mesagem = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user2, Texto = "Fala ai", Localizacao = "56156156", listaContatos = listaCont1 };
            var mesagem2 = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user1, Texto = "Tudo tranquilo", Localizacao = "56156156", listaContatos = listaCont2 };
            var mesagem3 = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user2, Texto = "Teste Mensagem", Localizacao = "56156156", listaContatos = listaCont1 };
            var mesagem4 = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user1, Texto = "Que horas", Localizacao = "56156156", listaContatos = listaCont2 };
            var mesagem5 = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user2, Texto = "Otario", Localizacao = "56156156", listaContatos = listaCont1 };
            var mesagem6 = new Mensagem { Id = 1, DataHora = new DateTime(2017, 10, 15, 10, 10, 10), Iniciador = user1, Texto = "Burrro", Localizacao = "56156156", listaContatos = listaCont2 };


            listaUsuario = new List<Usuario>();
            listaPerfil = new List<Perfil>();
            listaContato = new List<Contato>();
            listaMensagem = new List<Mensagem>();

            listaUsuario.Add(user1);
            listaUsuario.Add(user2);
            listaUsuario.Add(user3);
            listaUsuario.Add(user4);
            listaUsuario.Add(user5);

            listaPerfil.Add(perfil1);
            listaPerfil.Add(perfil2);
            listaPerfil.Add(perfil3);
            listaPerfil.Add(perfil4);
            listaPerfil.Add(perfil5);

            listaContato.Add(contato1);
            listaContato.Add(contato2);
            listaContato.Add(contato3);
            listaContato.Add(contato4);
            listaContato.Add(contato5);
            listaContato.Add(contato6);
            listaContato.Add(contato7);
            listaContato.Add(contato8);
            listaContato.Add(contato9);
            listaContato.Add(contato10);
            listaContato.Add(contato11);
            listaContato.Add(contato12);
            listaContato.Add(contato13);

            listaMensagem.Add(mesagem);
            listaMensagem.Add(mesagem2);
            listaMensagem.Add(mesagem3);
            listaMensagem.Add(mesagem4);
            listaMensagem.Add(mesagem5);
            listaMensagem.Add(mesagem6);
        }

    }
}
