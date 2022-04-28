using DirectoryService.Application.Models;
using DirectoryService.Application.Models.DTO;
using DirectoryService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Repositories
{
    public interface IContactRepository: IRepository<Contact>
    {
        Task<PaginatedList<ContactDto>> GetContactByPageAsync(int pageIndex,int pageCount);

        PersonCountByLocationDto PersonPhoneCount(string location);
    }

    
}
