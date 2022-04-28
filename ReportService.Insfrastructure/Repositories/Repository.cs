
using ReportService.Application.Repositories;
using ReportService.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Insfrastructure.Repositories
{

    public class Repository<T> : IRepository<T> where T : class
    {
        ReportDbContext _applicationDbContext;

        public Repository(ReportDbContext applicationDbContext)
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

        public IQueryable<T> Query(Func<T, bool> predicate)
        {

            if (predicate == null) return _applicationDbContext.Set<T>();

            return _applicationDbContext.Set<T>().Where(predicate).AsQueryable();
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
