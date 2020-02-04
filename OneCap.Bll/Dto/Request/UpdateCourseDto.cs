using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace OneCap.Bll.Dto.Request
{
    public class UpdateCourseDto
    {
        [Required]
        [MaxLength(Common.Constants.MAX_LEN_NAME), MinLength(Common.Constants.MIN_LEN_NAME)]
        public string Name { get; set; }

        [Required]
        public int Credits { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
