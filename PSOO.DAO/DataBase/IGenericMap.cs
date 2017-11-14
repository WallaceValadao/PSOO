using System.Data.Common;

namespace PSOO.DAO.DataBase
{
    public interface IGenericMap<T>
    {
        string GetId();
        T Get(T entity, DbDataReader read);
    }
}
