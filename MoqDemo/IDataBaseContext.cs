using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo
{
    interface IDataBaseContext<out T> where T : new()
    {
        T GetElementById(string id);
        IEnumerable<T> GetAll();
        IEnumerable<T> GetElementsByName(string name);
        IEnumerable<T> GetPageElementsByName(string name, int startPage = 0, int pageSize = 20);
        IEnumerable<T> GetElementsByDate(DateTime? startDate, DateTime? endDate);
    }
}
