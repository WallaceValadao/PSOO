using PSOO.Dominio;
using System;
using System.Collections.Generic;
using System.Data.Common;
using System.Linq;
using System.Linq.Expressions;

namespace PSOO.DAO.DataBase
{
    public abstract class GenericMap<T> : IGenericMap<T> where T : class, IEntidade
    {
        private string NomeTabela { get; set; }
        private string id { get; set; }

        private Dictionary<string, TypeBaseMap> mappingId;
        public Dictionary<string, TypeBaseMap> mapping { get; private set; }

        protected GenericMap()
        {
            this.mapping = new Dictionary<string, TypeBaseMap>();
            this.mappingId = new Dictionary<string, TypeBaseMap>();
        }

        protected void Tabela(string Tabela)
        {
            this.NomeTabela = Tabela;
        }

        protected void Map(Expression<Func<T, object>> nomePropriedade, string nomeColuna, string tipo)
        {
            var nome = nomePropriedade.ToString().Split('.').LastOrDefault();
            
            this.mapping.Add(nome, new TypeBaseMap
            {
                ColunaBanco = nomeColuna,
                TipoObjeto = nomePropriedade.Type,
                Tipo = tipo
            });
        }

        protected void Id(Expression<Func<T, object>> nomePropriedade, string nomeColuna, string tipo)
        {
            if (string.IsNullOrEmpty(id))
                this.id = nomeColuna;

            var nome = nomePropriedade.ToString().Split('.').LastOrDefault().Replace(")", "");

            this.mappingId.Add(nome, new TypeBaseMap
            {
                ColunaBanco = nomeColuna,
                TipoObjeto = nomePropriedade.Type,
                Tipo = tipo
            });
        }

        public string GetId() => this.id;

        public string GetTabela() => this.NomeTabela;

        public T Get(T entity, DbDataReader read)
        {
            foreach (var item in entity.GetType().GetProperties())
            {
                TypeBaseMap propriedade = null;
                var pular = true;

                if (mapping.TryGetValue(item.Name, out propriedade))
                    pular = false;
                else if (mappingId.TryGetValue(item.Name, out propriedade))
                    pular = false;

                if (pular)
                    continue;

                if (propriedade.Tipo.ToUpper() == (typeof(string)).Name.ToUpper())
                {
                    var result = read[propriedade.ColunaBanco].ToString();
                    item.SetValue(entity, result);
                }
                else if (propriedade.Tipo.ToUpper() == "int".ToUpper())
                {
                    var result = int.Parse(read[propriedade.ColunaBanco].ToString());
                    item.SetValue(entity, result);
                }
                else if (propriedade.Tipo.ToUpper() == "long".ToUpper())
                {
                    var result = long.Parse(read[propriedade.ColunaBanco].ToString());
                    item.SetValue(entity, result);
                }
                else if (propriedade.Tipo.ToUpper() == (typeof(DateTime)).Name.ToUpper())
                {
                    var result = DateTime.Parse(read[propriedade.ColunaBanco].ToString());
                    item.SetValue(entity, result);
                }
            }

            return entity;
        }
    }
}
