using Microsoft.Owin;
using Owin;

[assembly: OwinStartupAttribute(typeof(direccion_evaluacion.Startup))]
namespace direccion_evaluacion
{
    public partial class Startup
    {
        public void Configuration(IAppBuilder app)
        {
            ConfigureAuth(app);
        }
    }
}
