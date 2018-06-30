using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using GameTime.Models;
using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(GameTime.Startup))]
namespace GameTime
{
    public partial class Startup
    {
       /// <summary>
      /// este método é executado apenas 1 (uma) vez
      /// quando a aplicação arranca
      /// </summary>
      /// <param name="app"></param>
      public void Configuration(IAppBuilder app) {
         ConfigureAuth(app);

         // invocar o método para iniciar a configuração
         // dos ROLES
         iniciaAplicacao();
      }


      /// <summary>
      /// cria, caso não existam, as Roles de suporte à aplicação: Agentes, Condutores
      /// cria, nesse caso, também, um utilizador...
      /// </summary>
      private void iniciaAplicacao() {

         ApplicationDbContext db = new ApplicationDbContext();

         var roleManager = new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(db));
         var userManager = new UserManager<ApplicationUser>(new UserStore<ApplicationUser>(db));

         // criar a Role 'Utilizador'
         if(!roleManager.RoleExists("Utilizador")) {
            // não existe a 'role'
            // então, criar essa role
            var role = new IdentityRole();
            role.Name = "Utilizador";
            roleManager.Create(role);
         }

         // criar a Role 'Admin'
         if(!roleManager.RoleExists("Admin")) {
            // não existe a 'role'
            // então, criar essa role
            var role = new IdentityRole();
            role.Name = "Admin";
            roleManager.Create(role);
         }

         // criar um utilizador 'Utilizador'
         var user = new ApplicationUser();
         user.UserName = "tania@mail.pt";
         user.Email = "tania@mail.pt";
         //  user.Nome = "Luís Freitas";
         string userPWD = "123_Asd";
         var chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Utilizador-
            if (chkUser.Succeeded) {
            var result1 = userManager.AddToRole(user.Id, "Utilizador");
         }

         // criar um utilizador 'Admin' - André
         user = new ApplicationUser();
         user.UserName = "andre@mail.pt";
         user.Email = "andre@mail.pt";
         //  user.Nome = "Luís Freitas";
         userPWD = "123_Asd";
         chkUser = userManager.Create(user, userPWD);

            //Adicionar o Utilizador à respetiva Role-Admin-
            if (chkUser.Succeeded) {
            var result1 = userManager.AddToRole(user.Id, "Admin");
         }

      }

      // https://code.msdn.microsoft.com/ASPNET-MVC-5-Security-And-44cbdb97

    }
}
