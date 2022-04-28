using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Core.DomainClasses
{
    public class ContactInformation
    {
        public int Id { get; set; }
        public int ContactId { get; set; }
        public Contact Contact { get; set; }

        public string PhoneNumber { get; set; }
        public string Email { get; set; }
        public string Address { get; set; }

    }
}
