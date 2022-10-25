using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models.DomainModels.AAADomainModels.Dtos
{
    public class CreateRoleModel
    {
        [Required]
        public string RoleName { get; set; }
    }
}
