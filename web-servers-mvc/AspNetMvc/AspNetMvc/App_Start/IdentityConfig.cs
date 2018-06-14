using AspNetMvc.DataAccess.DataSource;
using Microsoft.AspNet.Identity;
using Microsoft.AspNet.Identity.EntityFramework;
using Microsoft.AspNet.Identity.Owin;
using Microsoft.Owin;
using Microsoft.Owin.Security.Cookies;
using Owin;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

[assembly: OwinStartup(typeof(AspNetMvc.IdentityConfig))]
namespace AspNetMvc
{
    public class IdentityConfig
    {
        public void Configuration(IAppBuilder app)
        {
            app.CreatePerOwinContext(() => new NorthwindContext());

            app.CreatePerOwinContext(
                (IdentityFactoryOptions<UserManager<IdentityUser, string>> options, IOwinContext context) => new UserManager<IdentityUser, string>(new UserStore<IdentityUser>(context.Get<NorthwindContext>()))
            );

            app.CreatePerOwinContext(
                (IdentityFactoryOptions<RoleManager<IdentityRole>> options, IOwinContext context) => new RoleManager<IdentityRole>(new RoleStore<IdentityRole>(context.Get<NorthwindContext>()))
            );

            app.UseCookieAuthentication(new CookieAuthenticationOptions
            {
                AuthenticationType = DefaultAuthenticationTypes.ApplicationCookie,
                LoginPath = new PathString("/Home/Login")
            });

            app.UseExternalSignInCookie(DefaultAuthenticationTypes.ExternalCookie);

            app.UseGoogleAuthentication(
                clientId: "shukwaze",
                clientSecret: "000000000000000000000000000000"
            );
        }
    }
}