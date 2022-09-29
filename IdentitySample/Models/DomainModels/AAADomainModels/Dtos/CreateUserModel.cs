using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models.DomainModels.AAADomainModels.Dtos
{
    public class CreateUserModel //can be as UserViewModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        [EmailAddress]
        public string Email { get; set; }
        [Required]
        public string Password { get; set; }
    }
}
