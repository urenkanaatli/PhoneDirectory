using System;
using System.Collections.Generic;
using System.Text;

namespace ReportService.Application.DTOs
{
   public class ReportInfoFromUserDto
    {
        public string Location { get; set; }
        public int UserCount { get; set; }
        public int PhoneCount { get; set; }
    }
}
