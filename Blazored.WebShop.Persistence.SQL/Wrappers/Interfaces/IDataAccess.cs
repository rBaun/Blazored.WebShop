using System.Collections.Generic;

namespace Blazored.WebShop.Persistence.SQL.Wrappers.Interfaces
{
    public interface IDataAccess
    {
        T QuerySingle<T, TU>(string sqlStatement, TU parameters);
        T QueryFirst<T, TU>(string sqlStatement, TU parameters);
        List<T> QueryList<T, TU>(string sqlStatement, TU parameters);
        void ExecuteCommand<T>(string sqlStatement, T parameters);
    }
}
