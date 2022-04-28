﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.UOW
{
    public interface IUnitOfWork
    {
        Task CommitAsync(CancellationToken cancellationToken);
   
    }
}
