using Abp.Application.Services.Dto;
using Abp.AutoMapper;
using blockchainGob.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace blockchainGob.Services.Complaint
{
    [AutoMap(typeof(Entities.Complaint))]
    public class ComplaintDto: EntityDto<Guid>
    {
        public string Applicant { get; set; }
        public string Defendant { get; set; }
        public TypeProcess TypeProcess { get; set; } = TypeProcess.Family;
    }
}
