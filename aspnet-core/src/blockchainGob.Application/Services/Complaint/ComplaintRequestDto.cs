using Abp.Application.Services.Dto;
using System;

namespace blockchainGob.Services.Complaint
{
    public class ComplaintRequestDto : EntityDto<Guid>
    {
        public string NewApplicant { get; set; }
        public string NewDefendant { get; set; }
        public string NewGuid { get; set; }
        public string NewTypeProcess { get; set; }
    }
}
