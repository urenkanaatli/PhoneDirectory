using AutoMapper;
using MediatR;
using ReportService.Application.Repositories;
using ReportService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using AutoMapper.QueryableExtensions;
using ReportService.Application.DTOs;

namespace ReportService.Application.Operations.Reports.Queries
{
    public class GetReportQuery : IRequest<List<ReportDto>>
    {
    }

    public class GetReportQueryHendler : IRequestHandler<GetReportQuery, List<ReportDto>>
    {

        private readonly IRepository<Report> _reportRepository;
        private readonly IMapper _mapper;

        public GetReportQueryHendler(IRepository<Report> reportRepository, IMapper mapper)
        {
            _reportRepository = reportRepository;
            _mapper = mapper;

        }

        public async Task<List<ReportDto>> Handle(GetReportQuery request, CancellationToken cancellationToken)
        {
            List<ReportDto> result = _reportRepository.Query().ProjectTo<ReportDto>(_mapper.ConfigurationProvider).ToList();

            return result;

        }
    }
}
