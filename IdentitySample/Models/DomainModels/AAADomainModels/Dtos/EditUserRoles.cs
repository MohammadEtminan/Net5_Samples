using System.Collections.Generic;
using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models.DomainModels.AAADomainModels.Dtos
{
    public class EditUserRoles //can be as UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string UserId { get; set; }
        [Required]

        public List<string> UserRoles { get; set; }
        [Required]
        public List<IdentityRole> Roles { get; set; }
    }
}
