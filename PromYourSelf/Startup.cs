using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Models;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Infrastructure;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using ReflectionIT.Mvc.Paging;
using PromYourSelf.BLL.Interfaces;
using PromYourSelf.BLL;
using PromYourSelf.Models;
using Microsoft.AspNetCore.Identity;

namespace PromYourSelf
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            services.Configure<CookiePolicyOptions>(options =>
            {
                // This lambda determines whether user consent for non-essential cookies is needed for a given request.
                options.CheckConsentNeeded = context => true;
                options.MinimumSameSitePolicy = SameSiteMode.None;
            });
            //Aqui inyetamos la conexion con la base de datos.
            services.AddEntityFrameworkSqlServer()
                .AddDbContext<Contexto>(options => options.UseSqlServer(Configuration["ConnectionStrings:ConStr"]));

            services.AddIdentity<Usuarios, Roles>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequiredLength = 6;
                options.Password.RequireLowercase = false;
                options.Password.RequireNonAlphanumeric = false;
                options.Password.RequireUppercase = false;
            }
           ).AddEntityFrameworkStores<Contexto>().AddDefaultTokenProviders();

            //Donde redirecciona cuando no estan autorizados a ver paginas
            services.ConfigureApplicationCookie(options =>
            {
                options.LoginPath = "/EntradaApp/Login";  //Cuando alguien no tenga permiso a una pagina, lo enviara aqui.
                options.AccessDeniedPath = "/EntradaApp/AccesoDenegado";
                options.Cookie.Name = ".applicationname";
                options.Cookie.HttpOnly = true; // This must be true to prevent XSS
                options.Cookie.SameSite = SameSiteMode.None;
                options.Cookie.SecurePolicy = CookieSecurePolicy.SameAsRequest;
            });

            //services.AddScoped<IRepositoryEmpleados, RepositorioEmpleado>();
            //services.AddScoped<IRepositoryCitas, RepositorioCitas>();
            //services.AddScoped<IRepositoryHorarios, RepositorioHorario>();
            //services.AddScoped<IRepositoryMensajes, RepositorioMensaje>();
            //services.AddScoped<IRepositoryNegocios, RepositorioNegocio>();
            //services.AddScoped<IRepositoryProductos, RepositorioProducto>();
            //services.AddScoped<IRepositoryUsuarios, RepositorioUsuario>();
            //services.AddScoped<IRepositoryVentas, RepositorioVenta>();
            services.AddScoped<IRepoWrapper, RepoWrapper>();

            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Home/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseCookiePolicy();

            app.UseMvc(routes =>
            {
                routes.MapRoute(
                    name: "default",
                    template: "{controller=DashBoard}/{action=DashBoard}/{id?}");
            });
        }
    }
}
