using Microsoft.Owin;
using Owin;
using EjercicioMVC3.Models;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;

[assembly: OwinStartupAttribute(typeof(EjercicioMVC3.Startup))]
namespace EjercicioMVC3
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {

            ConfigureAuth(app);
            CreateUserRol();

        }
        //Creacion de metodo para roles
        private void CreateUserRol()
        {
            //Acceder al Modelo de Seguridad
            ApplicationDbContext context = new ApplicationDbContext();
            //Manejador de roles y usuarios
            var ManejadorRol = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context));
            var ManejandoUser = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(context));

            //Verificamos la exitencia de un rol
            //rol Admin
            if (!ManejadorRol.RoleExists("Admin"))
            {
                //Creamos el rol por primera vez
                var rol = new IdentityRole();
                //Establecemos sus valores
                rol.Name = "Admin";
                ManejadorRol.Create(rol);

                //Asignamos a su primer usuario
                var user = new ApplicationUser();
                //Asignamos los valores
                user.UserName = "Admin@gmail.com";
                user.Email = "Admin@gmail.com";
                string pwd = "password";
                //Agregamos el usuario
                var verificar = ManejandoUser.Create(user, pwd);
                //Asignamos el usuario a un rol
                if (verificar.Succeeded)
                {
                    var result = ManejandoUser.AddToRole(user.Id, "Admin");
                }

            }

            //rol Director
            if (!ManejadorRol.RoleExists("Director"))
            {
                //Creamos el rol por primera vez
                var rol = new IdentityRole();
                //Establecemos sus valores
                rol.Name = "Director";
                ManejadorRol.Create(rol);

                //Asignamos a su primer usuario
                var user = new ApplicationUser();
                //Asignamos los valores
                user.UserName = "Director@gmail.com";
                user.Email = "Director@gmail.com";
                string pwd = "password";
                //Agregamos el usuario
                var verificar = ManejandoUser.Create(user, pwd);
                //Asignamos el usuario a un rol
                if (verificar.Succeeded)
                {
                    var result = ManejandoUser.AddToRole(user.Id, "Director");
                }

            }

            //rol Actor
            if (!ManejadorRol.RoleExists("Actor"))
            {
                //Creamos el rol por primera vez
                var rol = new IdentityRole();
                //Establecemos sus valores
                rol.Name = "Actor";
                ManejadorRol.Create(rol);

                //Asignamos a su primer usuario
                var user = new ApplicationUser();
                //Asignamos los valores
                user.UserName = "Actor@gmail.com";
                user.Email = "Actor@gmail.com";
                string pwd = "password";
                //Agregamos el usuario
                var verificar = ManejandoUser.Create(user, pwd);
                //Asignamos el usuario a un rol
                if (verificar.Succeeded)
                {
                    var result = ManejandoUser.AddToRole(user.Id, "Actor");
                }

            }
        }
    }
}
