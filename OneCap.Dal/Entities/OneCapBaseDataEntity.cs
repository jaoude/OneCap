using OneCap.Dal.Interfaces;
using System.ComponentModel.DataAnnotations;


namespace OneCap.Dal.Entities
{

    public abstract class OneCapBaseDataEntity : OneCapBaseEntity<int>, IHasConcurrency/*, IHasFullAudit*/
    {
        [Timestamp]
        public byte[] RowVersion { get; set; }
    }
}
