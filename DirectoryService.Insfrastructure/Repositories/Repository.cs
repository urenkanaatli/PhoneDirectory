using DirectoryService.Application.Repositories;
using DirectoryService.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Insfrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        ContactDbContext _applicationDbContext;

        public Repository(ContactDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

        public void Add(T entity)
        {

            _applicationDbContext.Set<T>().Add(entity);
        }

        public List<T> GetAll()
        {
            return _applicationDbContext.Set<T>().ToList();
        }

        public T GetById(object id)
        {

            return _applicationDbContext.Set<T>().Find(id);
        }

        public List<T> Query(Func<T, bool> predicate)
        {
            return _applicationDbContext.Set<T>().Where(predicate).ToList();
        }

        public void Remove(T entity)
        {
            _applicationDbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }

        public int Save()
        {
            return _applicationDbContext.SaveChanges();
        }

        public void Update(T entity)
        {
            _applicationDbContext.Entry<T>(entity).State = Microsoft.EntityFrameworkCore.EntityState.Deleted;
        }
    }
}
