using PSOO.DAO.DataBase;
using PSOO.Dominio;
using PSOO.IDAO;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Reflection;

namespace PSOO.DAO
{
    public abstract class DAO<T> : GenericDataBase, IDAO<T> where T : class, IEntidade
    {
        private Type Mapping { get; set; }
        private GenericMap<T> genericMap { get; set; } 

        public DAO(IConexao Conexao) : base(Conexao)
        {
            this.genericMap = (GenericMap<T>)GerenteMapeamento.getInstance(Conexao.NameSpaceMap)
                                        .getInstanceMap<T>(typeof(T).Name);

            this.Mapping = this.genericMap.GetType();
        }

        public T BuscarPorId(int Id)
        {
            var sql = string.Format("SELECT * FROM {0} WHERE {1} = :id ",
                    this.genericMap.GetTabela(),
                    this.genericMap.GetId()
                );

            var dic = new Dictionary<string, object>();
            dic.Add("id", Id);

            var read = ExecuteReader(sql, dic);

            if (!read.Read())
                return null;

            return this.genericMap.Get(this.CreateInstance(), read);
        }

        public void Deletar(T entidade)
        {
            var sql = $"DELETE FROM {this.genericMap.GetTabela()} where {this.genericMap.GetId()} = :id";

            var dic = new Dictionary<string, object>();
            dic.Add("id", entidade.Id);

            var result = ExecuteNonQuery(sql, dic);
        }

        public List<T> Listar()
        {
            var sql = string.Format("SELECT * FROM {0}", this.genericMap.GetTabela());
            
            var read = ExecuteReader(sql);

            var lista = new List<T>();

            while (read.Read())
                lista.Add(this.genericMap.Get(this.CreateInstance(), read));
            
            return lista;
        }

        public void Salvar(T entidade)
        {
            var colunas = string.Empty;
            var valor = string.Empty;

            foreach(var item in this.genericMap.mapping)
            {
                colunas += item.Value.ColunaBanco + ",";
                valor += "'" + entidade.GetType().GetProperty(item.Key).GetValue(entidade).ToString() + "',";
            }

            colunas = colunas.Remove(colunas.Length -1);
            valor = valor.Remove(valor.Length - 1);

            var sql = string.Format("INSERT INTO {0}({1}) values({2})",
                    this.genericMap.GetTabela(),
                    colunas, valor
                );

            var result = ExecuteNonQuery(sql);
        }

        private T CreateInstance()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }


    //public abstract class DAO<T> : IDAO<T> where T : class, IEntidade
    //{
    //    protected IConexao Conexao {  get; private set; }

    //    public DAO(IConexao Conexao)
    //    {
    //        this.Conexao = Conexao;
    //        Dados.Gerar();
    //    }

    //    public T BuscarPorId(int id)
    //    {
    //        if (typeof(T) == typeof(Usuario))
    //            return (T)Convert.ChangeType(Dados.listaUsuario.Where(x => x.Id == id).FirstOrDefault(), typeof(T));
    //        else if(typeof(T) == typeof(Contato))
    //            return (T)Convert.ChangeType(Dados.listaContato.Where(x => x.Id == id).FirstOrDefault(), typeof(T));
    //        else if (typeof(T) == typeof(Mensagem))
    //            return (T)Convert.ChangeType(Dados.listaMensagem.Where(x => x.Id == id).FirstOrDefault(), typeof(T));
    //        else if (typeof(T) == typeof(Perfil))
    //            return (T)Convert.ChangeType(Dados.listaPerfil.Where(x => x.Id == id).FirstOrDefault(), typeof(T));

    //        return null;
    //    }

    //    public void Deletar(T entidade)
    //    {
    //        if (typeof(T) == typeof(Usuario))
    //        {
    //            var user = (Usuario)Convert.ChangeType(entidade, typeof(Usuario));

    //            Dados.listaUsuario.Remove(user);
    //        }
    //        else if (typeof(T) == typeof(Contato))
    //        {
    //            var user = (Usuario)Convert.ChangeType(entidade, typeof(Usuario));

    //            Dados.listaUsuario.Remove(user);
    //        }
    //        else if (typeof(T) == typeof(Mensagem))
    //        {
    //            var user = (Usuario)Convert.ChangeType(entidade, typeof(Usuario));

    //            Dados.listaUsuario.Remove(user);
    //        }
    //        else if (typeof(T) == typeof(Perfil))
    //        {
    //            var user = (Usuario)Convert.ChangeType(entidade, typeof(Usuario));

    //            Dados.listaUsuario.Remove(user);
    //        }
    //    }

    //    public List<T> Listar()
    //    {
    //        if (typeof(T) == typeof(Usuario))
    //            return (List<T>)Convert.ChangeType(Dados.listaUsuario, typeof(List<T>));
    //        else if (typeof(T) == typeof(Contato))
    //            return (List<T>)Convert.ChangeType(Dados.listaContato, typeof(List<T>));
    //        else if (typeof(T) == typeof(Mensagem))
    //            return (List<T>)Convert.ChangeType(Dados.listaMensagem, typeof(List<T>));
    //        else if (typeof(T) == typeof(Perfil))
    //            return (List<T>)Convert.ChangeType(Dados.listaPerfil, typeof(List<T>));

    //        return null;
    //    }

    //    public void Salvar(T entidade)
    //    {
    //        if (typeof(T) == typeof(Usuario))
    //            Dados.listaUsuario.Add((Usuario)Convert.ChangeType(entidade, typeof(Usuario)));
    //        else if (typeof(T) == typeof(Contato))
    //            Dados.listaContato.Add((Contato)Convert.ChangeType(entidade, typeof(Usuario)));
    //        else if (typeof(T) == typeof(Mensagem))
    //            Dados.listaMensagem.Add((Mensagem)Convert.ChangeType(entidade, typeof(Usuario)));
    //        else if (typeof(T) == typeof(Perfil))
    //            Dados.listaPerfil.Add((Perfil)Convert.ChangeType(entidade, typeof(Perfil)));
    //    }
    //}
}
