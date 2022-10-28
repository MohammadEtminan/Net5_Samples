using System.ComponentModel.DataAnnotations;

namespace IdentitySample.Models.DomainModels.AAADomainModels.Dtos
{
    public class LoginModel
    {
        [Required]
        public string UserName { get; set; }
        [Required]
        public string Password { get; set; }
        public bool RememberMe { get; set; }
        public string RedirectUrl { get; set; }
    }
}
