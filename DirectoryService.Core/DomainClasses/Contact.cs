using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Core.DomainClasses
{
    public class Contact
    {
        public int ID { get; set; }
        public string Name { get; set; }

        public string LastName { get; set; }

        public string Firm { get; set; }

        public ICollection<ContactInformation> ContactInformations { get; set; }


    }
}
