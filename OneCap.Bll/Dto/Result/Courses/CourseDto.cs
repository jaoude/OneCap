using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Bll.Dto.Result
{
    public class CourseDto
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }

        public byte[] RowVersion { get; set; }
    }
}
