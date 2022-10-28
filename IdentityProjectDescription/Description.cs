namespace IdentityProjectDescription
{
    public class Description
    {
        #region [- Step 1: Adding required packages -]
        //	Microsoft.Entityframeworkcore.Tools
        //	Microsoft.Entityframeworkcore.Design
        //	Microsoft.Entityframeworkcore.Sqlserver
        //	Microsoft.AspNetCore.Identity.EntityFrameworkCore
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

        #region [- Step 5 : Creating Database : Migration & Update database -]
        //PM> add-migration InitialMigration
        //PM> update-database
        #endregion

        #region [- Step 6: Creating User Pipeline -]

        #region [- Create UserController -]
        //Create UserController
        //use UserManager in UsersController (IOC)
        //use _userManager in the Index action 
        #endregion

        #region [- Create Index page -]
        //Create User file in View layer and add Index.chtml to show user list.
        //Develop Index.chtml
        //Create <a> for Creating user in the Index page 
        #endregion

        //Create RegisterUser action in UserController
        //Add CreateUserModel as User Dto for registering User in AAADomainModels >> Dtos
        //add Identity to _ViewImports : @using Microsoft.AspNetCore.Identity
        //add Identity to _ViewImports : @using IdentitySample.Models.DomainModels.AAADomainModels.Dtos
        //develop RegisterUser.cshtml
        //Create post action of register user
        //change password policy in startup.cs ==> services.Configure<IdentityOptions>
        //create Delete User action
        //create Delete button to Index of User
        #endregion

        #region [- Step 7 : Creating Role Pipeline -]
        //Create RoleController
        //Inject RoleManager<IdentityRole> by ctor
        //Create Index view to show roles
        //Create 'CreateRoleModel'
        //Create RegisterRole and Delete like User with role manager
        //Create menu for Roles like Users
        #endregion

        #region [- Step 8 : Assigning Roles to a user -]
        //Assign roles to users by usermanager
        //Show users and his/her roles:
        //Create EditUserRoles as ViewModel
        //Inject rolemanager into the UserController
        //Create EditUserRoles action in UserController
        //Create EditUserRoles page
        //Create Edit Roles in User Index
        #endregion

        #region [- Step 9 : Create Authentication Pipeline -]
        //User Challenge process: This process starts when a user can not loging :
        //Redirect user to Invalid username or password page [Http response status 401]

        //Add up Authenticate middleware between UseRouting and UseAuthorization middlewares
        //Create LoginModel
        //Create AccountController
        //Create Login Get action
        //Create LoginPage
        //Create Login Post action
        //Inject SigninManger service as the Authenticate service
        //Use SigninManger as the Authenticate service        
        //Create Logout action
        #endregion

        #region [- Step 10 : Create Authorization flow -]
        //User Forbidden process: This process starts when a user can  login but is not Authorized to do sth:
        //Redirect user  Access Deny page [Http response status 403]

        //Use [Authorize] & [AllowAnonymous] on the Controller or Action
        //BackOffice apps : They need login for all pages except a few pages. ==> Use [AllowAnonymous] for those free pages
        //Office apps : They do not need login for all pages ==> Use [Authorize] for specific pages

        //Authorize UserController with [Authorize] 
        #endregion
    }
}
