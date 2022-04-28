using AutoMapper;
using DirectoryService.Application.Mappings;
using DirectoryService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Models.DTO
{
    public class ContactDto:IMapFrom<Contact>
    {
   

        public int ID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Firm { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Contact, ContactDto>();
        }
    }
}
