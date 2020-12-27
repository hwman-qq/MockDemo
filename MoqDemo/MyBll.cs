using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MoqDemo
{
    public class MyBll
    {
        private readonly IDataBaseContext<MyDto> _dataBaseContext;

        public MyBll(IDataBaseContext<MyDto> dataBaseContext)
        {
            _dataBaseContext = dataBaseContext;
        }

        public MyDto GetADto(string id)
        {
            if (string.IsNullOrWhiteSpace(id)) return null;
            return _dataBaseContext.GetElementById(id);
        }

        public IEnumerable<MyDto> GetDtos(string name)
        {
            if (string.IsNullOrWhiteSpace(name)) return null;
            var dtos = _dataBaseContext.GetElementsByName(name);
            return dtos;
        }

        public IEnumerable<MyDto> GetAllDtos()
        {
            var all = _dataBaseContext.GetAll().ToList();
            if (!all.Any()) return Enumerable.Empty<MyDto>();
            //一系列逻辑...
            var filteredDtos = all.Where(a => a.Age > 20);
            var orderDtos = filteredDtos.OrderBy(a => a.Name);
            return orderDtos;
        }
    }
}
