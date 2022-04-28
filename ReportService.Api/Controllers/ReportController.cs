using DirectoryService.Api.Controllers;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using ReportService.Application.DTOs;
using ReportService.Application.Operations.Reports.Commands;
using ReportService.Application.Operations.Reports.Queries;

namespace ReportService.Api.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController : ApiControllerBase
    {

        [HttpPost]
        public async Task<IActionResult> AddNewReport(CreateReportCommand createReportCommand)
        {

            ReportDto report = await  Mediator.Send(createReportCommand);
 
            return Ok("Your request has been received");

        }


        [HttpGet]
        public async Task<ActionResult<List<ReportDto>>> GetReports()
        {

            return await Mediator.Send(new GetReportQuery());
           
        }
    }
}
