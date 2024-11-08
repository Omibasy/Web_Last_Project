using Microsoft.AspNetCore.Mvc;

namespace Web_Last_Project
{
    public class Startup
    {
        public IConfiguration _configuration { get; }

        public Startup(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddMvc(TuningMvc);
        }

        public void Configure(IApplicationBuilder app, IServiceProvider service)
        {
            app.UseStaticFiles();

            app.UseExceptionHandler("/Exception/Mistake");

            app.UseMvc(GetRoute);
        }

        private void GetRoute(IRouteBuilder route)
        {
            route.MapRoute("home", "{controller=home}/{action=Index}");
        }

        private void TuningMvc(MvcOptions switches)
        {
            switches.EnableEndpointRouting = false;
        }
    }
}
