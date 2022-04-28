using ReportService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ReportService.Core.DomainClasses
{
    public class Report
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }
        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; }

        public ReportStatus Status { get; set; }
    }
}
