using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;


namespace IdentitySample.Models.DomainModels
{
    public class IdentitySampleDbContext : IdentityDbContext<IdentityUser>
    {
        public IdentitySampleDbContext(DbContextOptions options) : base(options)
        {
        }
    }
}
