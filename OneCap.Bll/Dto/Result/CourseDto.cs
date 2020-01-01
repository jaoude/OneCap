using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Bll.Dto.Result
{
    public class CourseDto
    {
        public Guid Id { get; set; }
        public string Name { get; set; }
        public int Credits { get; set; }
    }
}
