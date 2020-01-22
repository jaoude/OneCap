using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Bll.Dto.Result
{
    public class RoleDto
    {
        public string Id { get; set; }
        public string Name { get; set; }
        public string NormalizedName { get; set; }
        public string ConcurrencyStamp { get; set; }
    }
}
