using MySql.Data.MySqlClient;
using PSOO.IDAO;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.Common;
using System.Data.SqlClient;

namespace PSOO.DAO.DataBase
{
    public abstract class GenericDataBase : IDisposable
    {
        #region Construtor
        
        protected IConexao connectionManager;
        private string TipoParametro { get; set; }

        protected DbConnection conn { get; private set; }
        protected DbTransaction transacao { get; set; }

        public GenericDataBase(IConexao connectionManager)
        {
            this.connectionManager = connectionManager;
        }
        
        #endregion

        #region Transação
        
        protected void AbrirTransacao()
        {
            AbrirConexao();

            if (transacao == null)
                transacao = conn.BeginTransaction(IsolationLevel.ReadCommitted);
        }

        protected void FecharTransacao()
        {
            try
            {
                transacao?.Commit();
            }
            finally
            {
                transacao?.Dispose();

                transacao = null;
            }
        }

        protected void RollbackTransacao()
        {
            try
            {
                transacao?.Rollback();
            }
            finally
            {
                transacao?.Dispose();

                transacao = null;
            }
        }

        #endregion

        protected DbCommand GerarParametros(Dictionary<string, object> parametros)
        {
            var comando = conn.CreateCommand();

            if (parametros != null)
            {
                foreach (var item in parametros)
                {

                    if(connectionManager.TipoBanco == Dominio.Enumeradores.TipoBanco.MySQL)
                    {
                        comando.Parameters.Add(new MySqlParameter
                        {
                            ParameterName = string.Format("@{0}", item.Key),
                            MySqlDbType = MySqlDbType.Int64,
                            Value = item.Value
                        });
                        continue;
                    }

                    var parametro = comando.CreateParameter();

                    parametro = new SqlParameter();

                    parametro.ParameterName = string.Format("{0}{1}", this.TipoParametro, item.Key);

                    if (item.Value != null)
                        parametro.Value = item.Value;
                    else
                        parametro.Value = DBNull.Value;
                }
            }

            return comando;
        }

        protected DbConnection AbrirConexao()
        {
            if (conn == null)
            {
                if (this.connectionManager.TipoBanco == Dominio.Enumeradores.TipoBanco.MySQL)
                {
                    this.TipoParametro = "@";
                    conn = new MySqlConnection(connectionManager.ConnectionString);
                }
                else if (this.connectionManager.TipoBanco == Dominio.Enumeradores.TipoBanco.SqlServer)
                {
                    this.TipoParametro = "@";
                    conn = new SqlConnection(connectionManager.ConnectionString);
                }
            }
                
            if(conn.State == ConnectionState.Open)
                conn.Close();

            conn.Open();

            return conn;
        }

        protected void FecharConexao()
        {
            conn.Dispose();
            conn.Close();
        }

        protected int ExecuteNonQuery(string sql, Dictionary<string, object> parametros = null)
        {
            try
            {
                AbrirConexao();

                var command = GerarParametros(parametros);

                command.CommandText = sql.Replace(":", TipoParametro);
                
                return command.ExecuteNonQuery();
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
   
        protected int ExecuteScalar(string sql, Dictionary<string, object> parametros = null)
        {
            try
            {
                AbrirConexao();
                
                var command = GerarParametros(parametros);

                command.CommandText = sql.Replace(":", TipoParametro); ;

                var result = command.ExecuteScalar();

                return int.Parse(result.ToString());
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }

        protected DbDataReader ExecuteReader(string sql, Dictionary<string, object> parametros = null)
        {
            try
            {
                AbrirConexao();

                var command = GerarParametros(parametros);

                command.CommandText = sql.Replace(":", TipoParametro);

                var aaa =  command.ExecuteReader();

                return aaa;
            }
            catch (Exception ex)
            {
                throw ex;
            }
            finally
            {
                //FecharConexao();
            }
        }

        public void Dispose()
        {
            FecharConexao();
        }
    }
}