using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Optimization;
using System.Web.Routing;
using System.Web.Security;
using System.Web.SessionState;

namespace proyecto5
{
    public class Global : HttpApplication
    {
        void Application_Start(object sender, EventArgs e)
        {
            
            // Código que se ejecuta al iniciar la aplicación
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            // Calienta el caché de reportes al arrancar (en segundo plano) y deja un
            // refresco periódico. Evita el "hueco" de caché vacío tras un reciclaje
            // del App Pool o entre warmups programados, que hacía caer el dashboard.
            ReportCache.Initialize("INVERSIONESGGSA");
        }

        public override string GetVaryByCustomString(HttpContext context, string custom)
        {
            if (custom == "user")
            {
                return context.User.Identity.Name;
            }

              return base.GetVaryByCustomString(context, custom);
        }
    }
}

