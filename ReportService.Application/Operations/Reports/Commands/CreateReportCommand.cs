using AutoMapper;
using EventBus.Base.Abstraction;
using MediatR;
using ReportService.Application.DTOs;
using ReportService.Application.Operations.Reports.IntegrationEvents;
using ReportService.Application.Repositories;
using ReportService.Application.UOW;
using ReportService.Core.DomainClasses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace ReportService.Application.Operations.Reports.Commands
{
    public class CreateReportCommand : IRequest<ReportDto>
    {
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
    }

    public class CreateReportCommandHendler : IRequestHandler<CreateReportCommand, ReportDto>
    {
        private readonly IRepository<Report> _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;
        private readonly IEventBus _eventBus;

        public CreateReportCommandHendler(IRepository<Report> reportRepository, IUnitOfWork unitOfWork, IMapper mapper, IEventBus eventBus)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
            _mapper = mapper;
            _eventBus = eventBus;

        }

        public async Task<ReportDto> Handle(CreateReportCommand request, CancellationToken cancellationToken)
        {

            Report report = new Report
            {
                ID = Guid.NewGuid(),
                Location = request.Location,
                ReportName = request.ReportName,
                RequestedDate = DateTime.Now,
                Status = Core.Enums.ReportStatus.InProgress
            };

            _reportRepository.Add(report);

            await _unitOfWork.CommitAsync(cancellationToken);

            _eventBus.Publish(new NewReportAddedIntegrationEvent(report.ID, report.RequestedDate));

            return _mapper.Map<ReportDto>(report);

        }
    }
}
