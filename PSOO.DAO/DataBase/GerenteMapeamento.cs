using PSOO.Dominio;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;

namespace PSOO.DAO.DataBase
{
    public class GerenteMapeamento
    {
        #region Construtor

        private static GerenteMapeamento instance;
		private Dictionary<string, object> maps { get; set; }

        private GerenteMapeamento(string nameSpaceMap)
        {
			this.maps = new Dictionary<string, object>();
			
			var classes = Assembly.GetExecutingAssembly().GetTypes()
                      .Where(t => t.Namespace == nameSpaceMap)
                      .ToList();
            
			foreach(var item in classes)
			{
				var nome = item.Name.ToString().Replace("Map", "");

                maps.Add(nome, Activator.CreateInstance(item));
			}
        }
		
		public static GerenteMapeamento getInstance(string nameSpaceMap)
		{
			if(instance == null)
				instance = new GerenteMapeamento(nameSpaceMap);
			
			return instance;
		}
        
        #endregion
		
		public object getInstanceMap<T>(string entidade) where T : class, IEntidade
		{
			object instanciaClasse = null;
			
			if(!maps.TryGetValue(entidade, out instanciaClasse))
				throw new Exception("Entidade não mapeada");
			
			return instanciaClasse;
		}
	}
}