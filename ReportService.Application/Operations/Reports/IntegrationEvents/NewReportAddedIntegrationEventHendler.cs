
using EventBus.Base.Abstraction;
using EventBus.Base.Events;
using Newtonsoft.Json;
using ReportService.Application.DTOs;
using ReportService.Application.Repositories;
using ReportService.Application.UOW;
using ReportService.Core.DomainClasses;
using RestSharp;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Operations.Reports.IntegrationEvents
{
    public class NewReportAddedIntegrationEventHendler : IIntegrationEventHandler<NewReportAddedIntegrationEvent>
    {

        private readonly IRepository<Report> _reportRepository;
        private readonly IUnitOfWork _unitOfWork;
        public NewReportAddedIntegrationEventHendler(IRepository<Report> reportRepository, IUnitOfWork unitOfWork)
        {
            _reportRepository = reportRepository;
            _unitOfWork = unitOfWork;
        }

        public async Task Handle(NewReportAddedIntegrationEvent @event)
        {

            Report report= _reportRepository.GetById(@event.Id);

            var client = new RestClient("http://localhost:5001/directoryservice/CreateReport");
            var request = new RestRequest();
            request.Method = Method.Post;
            request.AddHeader("Content-Type", "application/json");
            var data = new PhoneNumbersReportRequest
            {
                Location = @event.Location

            };

        
            request.AddParameter("application/json", JsonConvert.SerializeObject(data), ParameterType.RequestBody);

            RestResponse response=await client.ExecuteAsync(request);

            var responsedata = JsonConvert.DeserializeObject<ReportInfoFromUserDto>(response.Content);
            report.PhoneCount = responsedata.PhoneCount;
            report.PersonCount = responsedata.UserCount;
            report.Status = Core.Enums.ReportStatus.Completed;

            await _unitOfWork.CommitAsync(new CancellationToken());

        }
    }
}
