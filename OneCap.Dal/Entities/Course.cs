using OneCap.Dal.Interfaces;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Text;

namespace OneCap.Dal.Entities
{
    [Table("Course")]
    public class Course : OneCapBaseDataEntity
    {
        [Required]
        [MaxLength(Common.Constants.MAX_LEN_NAME)]
        public string Name { get; set; }

        [Required]
        public int Credits { get; set; }

        [Required]
        public string TeacherName { get; set; }


        public string TeacherFamilyName { get; set; }

    }
}
