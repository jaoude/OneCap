using System.ComponentModel.DataAnnotations;

namespace OneCap.Bll.Dto.Request
{
    public class CreateRoleDto
    {
        [Required]
        public string RoleName { get; set; }
    }
}
