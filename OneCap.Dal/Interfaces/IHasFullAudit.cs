using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Dal.Interfaces
{
    public interface IHasFullAudit
    {
        public string CreatedBy { get; set; }
        public DateTime CreatedOn { get; set; }
        public string LastModifiedBy { get; set; }
        public DateTime? LastModifiedOn { get; set; }
        public string DeletedBy { get; set; }
        public DateTime? DeleltedOn { get; set; }
    }
}
