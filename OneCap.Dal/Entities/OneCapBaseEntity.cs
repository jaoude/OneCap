using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneCap.Dal.Entities
{
    public abstract class OneCapBaseEntity :  IHasConcurrency/*, IHasFullAudit*/
    {
        //public string CreatedBy { get; set; }
        //public DateTime CreatedOn { get; set; }
        //public string LastModifiedBy { get; set; }
        //public DateTime? LastModifiedOn { get; set; }
        //public string DeletedBy { get; set; }
        //public DateTime? DeleltedOn { get; set; }

        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
