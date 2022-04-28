using DirectoryService.Application.Operations.Contacts.Commands;
using DirectoryService.Core.DomainClasses;
using FluentAssertions;
using NUnit.Framework;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.IntegrationTests.Contacts
{
    using static Testing;

    public class CreateContactTests : TestBase
    {

        [Test]
        public void ShouldRequireMinimumFields()
        {
            var command = new AddContactCommand();

            FluentActions.Invoking(() =>
                SendAsync(command)).Should().ThrowAsync<ValidationException>();
        }


        [Test]
        public async Task ShouldCreateContact()
        {
           

            var command = new AddContactCommand
            {
                Name="Üren",
                LastName="Kanaatli",
                Firm="test"
            };

            var id = await SendAsync(command);

            var Contact = Get<Contact>(id);

            Contact.Should().NotBeNull();
            Contact.Name.Should().Be(command.Name);
            Contact.LastName.Should().Be(command.LastName);
            Contact.Firm.Should().Be(command.Firm);
        }
    }
}
