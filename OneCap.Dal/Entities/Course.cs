using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneCap.Dal.Entities
{
    [Table("Course")]
    public class Course : OneCapBaseEntity, IHasConcurrency//, IHasFullAudit
    {
        [Key]
        public int Id { get; set; }

        [Required]
        [MaxLength(Common.Constants.MAX_LEN_NAME)]
        public string Name { get; set; }

        [Required]
        public int Credits { get; set; }
    }
}
