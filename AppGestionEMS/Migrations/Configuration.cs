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
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
        }

        protected override void Seed(AppGestionEMS.Models.ApplicationDbContext context)
        {
            string roleAdministrador = "Administrador";
            string roleProfesor = "Profesor";
            string roleAlumno = "Alumno";

            AddRole(context, roleAdministrador);
            AddRole(context, roleProfesor);
            AddRole(context, roleAlumno);

            AddUser(context, "administrador", "xxx", "administrador@upm.es", roleAdministrador);
            AddUser(context, "Jessica", "apellidos1", "yesica.diaz@upm.es", roleProfesor);
            AddUser(context, "Carolina", " apellidos2 ", "carolina.gallardop@upm.es", roleProfesor);
            AddUser(context, "alumno1", " apellidos3 ", "alumno1@alumnos.upm.es", roleAlumno);
            AddUser(context, "alumno2", " apellidos4 ", "alumno2@alumnos.upm.es", roleAlumno);
            AddUser(context, "alumno3", " apellidos5 ", "alumno3@alumnos.upm.es", roleAlumno);
        }

        public void AddRole(ApplicationDbContext context, String role)
        {
            IdentityResult IdRoleResult;
            var roleStore = new RoleStore<IdentityRole>(context);
            var roleMgr = new RoleManager<IdentityRole>(roleStore);

            if (!roleMgr.RoleExists(role))
                IdRoleResult = roleMgr.Create(new IdentityRole { Name = role });
        }

        public void AddUser(ApplicationDbContext context, String name, String surname, String email, String role)
        {
            IdentityResult IdUserResult;
            var userMgr = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));
            var appUser = new ApplicationUser
            {
                Name = name,
                Surname = surname,
                UserName = email,
                Email = email,
            };
            IdUserResult = userMgr.Create(appUser, "123456Aa!");

            //asociar usuario con role             
            if (!userMgr.IsInRole(userMgr.FindByEmail(email).Id, role))
            {
                IdUserResult = userMgr.AddToRole(userMgr.FindByEmail(email).Id, role);
            }
        }
    }
}
