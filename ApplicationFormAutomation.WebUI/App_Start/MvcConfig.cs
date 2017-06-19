using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Routing;

namespace ApplicationFormAutomation.WebUI.App_Start
{
    public static class MvcConfig
    {
        public static IApplicationBuilder UseAndConfigureMvc(this IApplicationBuilder app)
        {
            return app.UseMvc(BuildRoutes);
        }
        private static void BuildRoutes(IRouteBuilder builder)
        {
            builder.MapRoute(
                    name: "default",
                    template: "{controller=Home}/{action=Index}/{id?}");
        }
    }
}
