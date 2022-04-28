using AutoMapper;
using AutoMapper.QueryableExtensions;
using DirectoryService.Application.Models;
using DirectoryService.Application.Models.DTO;
using DirectoryService.Application.Repositories;
using DirectoryService.Core.DomainClasses;
using DirectoryService.Insfrastructure.Data;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Insfrastructure.Repositories
{
    public class ContactRepository : Repository<Contact>, IContactRepository
    {
        private readonly ContactDbContext _applicationDbContext;
        private readonly IMapper _mapper;
        public ContactRepository(ContactDbContext applicationDbContext, IMapper mapper) : base(applicationDbContext)
        {
            _applicationDbContext = applicationDbContext;
            _mapper = mapper;
        }

        public async Task<PaginatedList<ContactDto>> GetContactByPageAsync(int pageIndex, int pageCount)
        {


            var data = _applicationDbContext.Contacts.OrderBy(x => x.ID)
              .ProjectTo<ContactDto>(_mapper.ConfigurationProvider);

            var count = await data.CountAsync();
            var items = await data.Skip((pageIndex - 1) * pageCount).Take(pageCount).ToListAsync();

            return  PaginatedList<ContactDto>.Create(items, count, pageIndex, pageCount);
        }

        public PersonCountByLocationDto PersonPhoneCount(string location)
        {

            List<int> counts = new List<int>();

            int userCount = _applicationDbContext.ContactInformations.Where(x => x.Address == location).Select(x => x.Id).ToList().Distinct().Count();
            counts.Add(userCount);

            int phoneCount = _applicationDbContext.ContactInformations.Where(x => x.Address == location).Select(x => x.PhoneNumber).ToList().Count();
            counts.Add(phoneCount);

            return new PersonCountByLocationDto
            {
                RegisterPersonCount= userCount,
                RegisterPhoneCount=phoneCount

            };
        }

      
    }
}
