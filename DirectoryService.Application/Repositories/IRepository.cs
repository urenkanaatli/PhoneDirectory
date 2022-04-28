using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Repositories
{
    public interface IRepository<T> where T : class
    {

        public T GetById(object id);

        public List<T> GetAll();

        public List<T> Query(Func<T, bool> predicate);

        public void Add(T entity);
        public void Remove(T entity);

        public void Update(T entity);

    }
}
