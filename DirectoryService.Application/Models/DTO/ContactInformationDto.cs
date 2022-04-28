using DirectoryService.Application.Mappings;
using DirectoryService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Models.DTO
{
    public class ContactInformationDto : IMapFrom<ContactInformation>
    {

        public int Id { get; set; }
        public int ContactId { get; set; }
        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }
    }
}
