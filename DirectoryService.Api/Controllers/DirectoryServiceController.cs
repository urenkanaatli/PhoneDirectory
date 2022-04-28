using DirectoryService.Application.Models;
using DirectoryService.Application.Models.DTO;
using DirectoryService.Application.Operations.Contacts.Commands;
using DirectoryService.Application.Operations.Contacts.Queries;
using DirectoryService.Application.Operations.Reports.Commands;
using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DirectoryService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DirectoryServiceController : ApiControllerBase
    {


        [HttpGet]
        public async Task<ActionResult<PaginatedList<ContactDto>>> GetTodoItemsWithPagination([FromQuery] GetContactsQuery query)
        {
            return await Mediator.Send(query);
        }


        [HttpPost]
        public async Task<ActionResult<int>> Create(AddContactCommand command)
        {

            return await Mediator.Send(command);
        }

        [HttpPut("{id}")]
        public async Task<ActionResult> Update(int id, UpdateContactCommand command)
        {
            if (id != command.Id)
            {
                return BadRequest();
            }

            await Mediator.Send(command);

            return NoContent();
        }

    

        [HttpDelete("{id}")]
        public async Task<ActionResult> Delete(int id)
        {
            await Mediator.Send(new RemoveContactCommand { Id = id });

            return NoContent();
        }

        [HttpPost("[action]")]
        public async Task<ActionResult<PersonCountByLocationDto>> CreateReport(PhoneNumbersReportRequest query)
        {
            return await Mediator.Send(query);
        }

    }
}
