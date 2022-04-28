using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Repositories
{
    public interface IRepository<T> where T : class
    {

        public T GetById(object id);

        public List<T> GetAll();

        public IQueryable<T> Query(Func<T, bool> predicate=null);

        public void Add(T entity);
        public void Remove(T entity);

        public void Update(T entity);

    }
}
