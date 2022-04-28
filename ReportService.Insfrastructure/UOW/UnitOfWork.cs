using ReportService.Application.UOW;
using ReportService.Insfrastructure.Data;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Insfrastructure.UOW
{
    public class UnitOfWork : IUnitOfWork
    {
        private readonly ReportDbContext _applicationDbContext;
        public UnitOfWork(ReportDbContext applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
        }

       
        public async Task CommitAsync(CancellationToken cancellationToken)
        {
          await  _applicationDbContext.SaveChangesAsync(cancellationToken);
        }
    }
}
