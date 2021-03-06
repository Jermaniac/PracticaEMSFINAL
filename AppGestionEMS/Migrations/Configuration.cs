namespace AppGestionEMS.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;
    using Microsoft.AspNet.Identity;
    using Microsoft.AspNet.Identity.EntityFramework;
    using Models;

    internal sealed class Configuration : DbMigrationsConfiguration<AppGestionEMS.Models.ApplicationDbContext>
    {

        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }
        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String password, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
                Password = password

            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");
            //asociar usuario con role
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String password, String role, String matricula)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
                Password = password,
                numMatricula = matricula
            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");
            //asociar usuario con role
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppGestionEMS.Models.ApplicationDbContext context)
        {
            string roleAdmin = "admin";
            string roleProfe = "profesor";
            string roleAlum = "alumno";
            AddRole(context, roleAdmin);
            AddRole(context, roleProfe);
            AddRole(context, roleAlum);
            AddUser(context, "admin", "admin", "admin@upm.es", "123456Aa!", roleAdmin);
            AddUser(context, "profesor1", "apell", "profesor1@upm.es", "123456Aa!", roleProfe);
            AddUser(context, "profesor2", "apell", "profesor2@upm.es", "123456Aa!", roleProfe);
            AddUser(context, "ficitio1", "apell", "ficticio1@alumnos.upm.es", "123456Aa!", roleAlum, "bn0001");
            AddUser(context, "ficitio2", "apell", "ficticio2@alumnos.upm.es", "123456Aa!", roleAlum, "bn0002");
            AddUser(context, "ficitio3", "apell", "ficticio3@alumnos.upm.es", "123456Aa!", roleAlum, "bn0003");
        }
    }
}