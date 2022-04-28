using DirectoryService.Application.Models.DTO;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace DirectoryService.Application.Operations.Reports.Commands
{
    public class PhoneNumbersReportRequest : IRequest<PersonCountByLocationDto>
    {
       
        public string Location { get; set; }
    }

    public class PhoneNumbersReportCommandHendler : IRequestHandler<PhoneNumbersReportRequest, PersonCountByLocationDto>
    {
        public async Task<PersonCountByLocationDto> Handle(PhoneNumbersReportRequest request, CancellationToken cancellationToken)
        {
            throw new NotImplementedException();
        }
    }

}
