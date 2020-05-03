using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Backend.DbManagement;
using Backend.Provider;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;

namespace Backend
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
            services.AddDbContext<Context>(options =>
                options.UseSqlServer(Configuration.GetConnectionString("DoctorApp")));
            services.AddScoped<IPatientDb, PatientDb>();
            services.AddScoped<IDoctorDb, DoctorDb>();
            services.AddScoped<IPatientAppointmentsDb, PatientAppointmentsDb>();
            services.AddScoped<IDoctorAppointmentsDb, DoctorAppointmentsDb>();
            services.AddScoped<IDoctorAppointmentTimesDb, DoctorAppointmentTimesDb>();
            services.AddScoped<ISpecializationsDb, SpecializationsDb>();
            services.AddScoped<IAppointmentDb, AppointmentDb>();
            services.AddScoped<ICitiesProvider, CitiesProvider>();
            services.AddControllers();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseHttpsRedirection();

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
