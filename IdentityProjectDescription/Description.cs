namespace IdentityProjectDescription
{
    public class Description
    {
        #region [- Step 1: Adding required packages -]
        //	Microsoft.AspNetCore.Identity.EntityFrameworkCore
        //	Microsoft.Entityframeworkcore.Design
        //	Microsoft.Entityframeworkcore.Sqlserver
        //	Microsoft.Entityframeworkcore.Tools
        #endregion

        #region [- Step 2: Creating required DbContext -]
        //IdentitySampleDbContext in Models >> DomainModels ===>  IdentitySampleDbContext:IdentityDbContext<IdentityUser>
        #endregion

        #region [- Step 3: Setting ConnectionString  -] 
        // in the appsettings.json
        #endregion

        #region [- Step 4 : Config required middlewares in Startup.cs -]
        //in ConfigureServices():
        //AddDbContext
        //AddIdentity
        #endregion
    }
}
