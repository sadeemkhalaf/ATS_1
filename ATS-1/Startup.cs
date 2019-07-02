using ATS_1.Data;
using ATS_1.Services;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;

namespace ATS_1
{
    public class Startup
    {

        readonly string allowedOrigins = "myAllowedOrigins";
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public IConfiguration Configuration { get; }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddCors(options => {
                options.AddPolicy(allowedOrigins, builder => {
                    builder.AllowAnyOrigin().AllowAnyMethod().AllowAnyHeader().AllowCredentials();
                });
            });
            services.AddMvc().SetCompatibilityVersion(CompatibilityVersion.Version_2_2);
            services.AddDbContext<ApplicationDBContext>(x => x.UseSqlServer(Configuration.GetConnectionString("ATSContext")), ServiceLifetime.Transient);
            services.AddTransient<IApplicantService, ApplicantService>();
            services.AddTransient<IMetadataService, MetadataService>();
            services.AddTransient<IInboxService, InboxService>();
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
                // The default HSTS value is 30 days. You may want to change this for production scenarios, see https://aka.ms/aspnetcore-hsts.
                app.UseHsts();
            }

            app.UseHttpsRedirection();
            app.UseCors(allowedOrigins);
            app.UseMvc();
        }
    }
}
