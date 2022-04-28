using EventBus.Base.Events;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Application.Operations.Reports.IntegrationEvents
{
    public class NewReportAddedIntegrationEvent : IntegrationEvent
    {
        public string Location { get; set; }
        public NewReportAddedIntegrationEvent(Guid id, DateTime createdDate) : base(id, createdDate)
        {
        }
    }
}
