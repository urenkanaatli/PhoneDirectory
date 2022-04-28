using DirectoryService.Application.Exceptions;
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
    public class RemoveContactCommand: IRequest
    {
        public int Id { get; set; }
    }

    public class RemoveContactCommandHendler : IRequestHandler<RemoveContactCommand>
    {

        private readonly IRepository<Contact> _contactRepository;
        private readonly IUnitOfWork _unitOfWork;

        public RemoveContactCommandHendler(IRepository<Contact> contactRepository, IUnitOfWork unitOfWork)
        {
            _contactRepository = contactRepository;
            _unitOfWork = unitOfWork;

        }
        public async Task<Unit> Handle(RemoveContactCommand request, CancellationToken cancellationToken)
        {

            Contact contact= _contactRepository.GetById(request.Id);

            if (contact == null)
            {

                throw new NotFoundException(request.GetType().Name, request.Id);
            }

            _contactRepository.Remove(contact);

            await _unitOfWork.CommitAsync(cancellationToken);

            return Unit.Value;


        }
    }

}
