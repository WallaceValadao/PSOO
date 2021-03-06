﻿using PSOO.DAO.DataBase;
using PSOO.Dominio;

namespace PSOO.DAO.Mapeamento
{
    public class UsuarioMap : GenericMap<Usuario>
    {
        public UsuarioMap()
        {
            Tabela("T_USUARIO");
            Id(x => x.Id, "ID_USUARIO", "int");
            Map(x => x.Nome, "DSC_NOME", "string");
            //Map(x => x.DataNascimento, "dat_nascimento");
            //Map(x => x.Localizacao, "localizacao");
            //Map(x => x.Foto, "foto");
            //Map(x => x.Status, "status");
            //Map(x => x.Numero, "numero");
            //Map(x => x.Login, "login");
            //Map(x => x.Senha, "senha");
        }
    }
}
