using DirectoryService.Application.Models;
using DirectoryService.Application.Models.DTO;
using DirectoryService.Application.Repositories;
using DirectoryService.Core.DomainClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Operations.Contacts.Queries
{
    public class GetContactsQuery : IRequest<PaginatedList<ContactDto>>
    {
        public int PageIndex { get; set; }

        public int PageCount { get; set; } = 10;
    }


    public class GetContactQueryHendler : IRequestHandler<GetContactsQuery, PaginatedList<ContactDto>>
    {
        private readonly IContactRepository _contactRepository;
        public GetContactQueryHendler(IContactRepository contactRepository)
        {
            _contactRepository = contactRepository;

        }

        public async Task<PaginatedList<ContactDto>> Handle(GetContactsQuery request, CancellationToken cancellationToken)
        {

            return await _contactRepository.GetContactByPageAsync(request.PageIndex, request.PageCount);


        }
    }


}
