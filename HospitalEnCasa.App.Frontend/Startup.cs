using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using HospitalEnCasa.App.Persistencia.AppRepositorios;

namespace HospitalEnCasa.App.Frontend
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
            services.AddRazorPages();
            services.AddSingleton<IRepositorioAuxiliar,RepositorioAuxiliar>();
            //services.AddSingleton<IRepositorioGenero,RepositorioGenero>();
            services.AddSingleton<IRepositorioEnfemero,RepositorioEnfermero>();
            services.AddSingleton<IRepositorioFamiliarDesignado,RepositorioFamiliarDesignado>();
            services.AddSingleton<IRepositorioHistorico,RepositorioHistorico>();
            services.AddSingleton<IRepositorioHogar,RepositorioHogar>();
            services.AddSingleton<IRepositorioHospital,RepositorioHospital>();
            services.AddSingleton<IRepositorioMedico,RepositorioMedico>();
            services.AddScoped<IRepositorioPaciente,RepositorioPaciente>();
            services.AddSingleton<IRepositorioPersona,RepositorioPersona>();
            services.AddSingleton<IRepositorioPersonalDeSalud,RepositorioPersonalDeSalud>();
            services.AddSingleton<IRepositorioSingoVital,RepositorioSignoVital>();
            services.AddSingleton<IRepositorioSugerenciaDeCuidado,RepositorioSugerenciaDeCuidado>();
           //services.AddDbContext<ApplicationContext>(options=>options.UseSqlServer(Configuration.GetConnectionString("DefaultConnection")));
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }
            else
            {
                app.UseExceptionHandler("/Error");
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseStaticFiles();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapRazorPages();
            });
        }
    }
}
