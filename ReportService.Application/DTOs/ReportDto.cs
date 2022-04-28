using AutoMapper;
using ReportService.Application.Mappings;
using ReportService.Core.DomainClasses;
using ReportService.Core.Enums;
using System;
using System.Collections.Generic;
using System.Text;

namespace ReportService.Application.DTOs
{
   public class ReportDto: IMapFrom<Report>
    {
        public Guid ID { get; set; }
        public string ReportName { get; set; }
        public string Location { get; set; }
        public int PersonCount { get; set; }

        public int PhoneCount { get; set; }
        public DateTime RequestedDate { get; set; } 
        public string CreatedDate { get; set; }

        public ReportStatus Status { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Report, ReportDto>();
        }
    }
}
