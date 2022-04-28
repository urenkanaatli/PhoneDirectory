using DirectoryService.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ContactDbContext _applicationDbContext;
        public UnitOfWork(ContactDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

       
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
          await  _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
