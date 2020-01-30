using Microsoft.AspNetCore.Authentication.JwtBearer;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OneCap.Api.Models
{
    public class OneCapJwtConstants
    {
        public const string Issuer = "MVS";
        public const string Audience = "ApiUser";
        public const string Key = "0123456789012345";
        public const string AuthSchemes =
            "Identity.Application" + "," + JwtBearerDefaults.AuthenticationScheme;
    }
}
