using System;
using System.Collections.Generic;
using System.Text;

namespace OneCap.Bll.Dto.Result
{
    public class UserClaimsDto
    {
        public UserClaimsDto()
        {
            Claims = new List<UserClaimDto>();
        }

        public string UserId { get; set; }
        public List<UserClaimDto> Claims { get; set; }
    }
}
