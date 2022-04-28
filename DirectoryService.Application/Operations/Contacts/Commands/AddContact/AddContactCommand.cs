using DirectoryService.Application.Repositories;
using DirectoryService.Application.UOW;
using DirectoryService.Core.DomainClasses;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Operations.Contacts.Commands
{
    public class AddContactCommand : IRequest<int>
    {

        public string Name { get; set; }

        public string LastName { get; set; }

        public string Firm { get; set; }
    }

    public class AddContactCommandHendler : IRequestHandler<AddContactCommand,int>
    {

        private readonly IRepository<Contact> _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public AddContactCommandHendler(IRepository<Contact> contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;

        }

        public async Task<int> Handle(AddContactCommand request, CancellationToken cancellationToken)
        {


            Contact contact = new Contact
            {
                Firm = request.Firm,
                LastName = request.LastName,
                Name = request.Name
            };

            _contactRepository.Add(contact);

            await _unitOfWork.CommitAsync(cancellationToken);


            return contact.ID;
        }
    }
}
