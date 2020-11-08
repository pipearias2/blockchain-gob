using Abp.Domain.Entities;
using Abp.Domain.Entities.Auditing;
using System;
using System.Collections.Generic;
using System.Text;

namespace blockchainGob.Entities
{
    public class Complaint : Entity<Guid>, IAudited
    {
        public string Applicant { get; set; }
        public string Defendant { get; set; }
        public TypeProcess TypeProcess { get; set; } = TypeProcess.Family;
        public long? CreatorUserId { get; set; }
        public DateTime CreationTime { get; set; }
        public long? LastModifierUserId { get; set; }
        public DateTime? LastModificationTime { get; set; }

    }
}
