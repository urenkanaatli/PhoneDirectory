using FluentValidation;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Operations.Contacts.Commands
{
    public class AddContactCommandValidator: AbstractValidator<AddContactCommand>
    {
        public AddContactCommandValidator()
        {

            RuleFor(t => t.Firm).MaximumLength(50).NotNull().NotEmpty();
            RuleFor(t => t.LastName).MaximumLength(50).NotNull().NotEmpty();
            RuleFor(t => t.Name).MaximumLength(50).NotNull().NotEmpty();
        }
    }
}
