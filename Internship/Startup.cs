using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Internship.Configuration;
using Internship.Core;
using Internship.Models;
using Internship.Service;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.HttpOverrides;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;

namespace Internship
{
    public class Startup
    {
        public IConfiguration Configuration { get; }
        
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddControllers();

            services.Configure<IISServerOptions>(options =>
            {
                options.AutomaticAuthentication = false;
            });

            services.AddDbContext<Context>(x => {
					x.UseSqlServer(Configuration["ProjectConfiguration:DatabaseConfiguration:ConnectionString"]);
					x.UseQueryTrackingBehavior(QueryTrackingBehavior.NoTracking);
					});;

			services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
						{
							 builder.AllowAnyOrigin()
									.AllowAnyMethod()
									.AllowAnyHeader();
						}));

            var config = new ProjectConfiguration();
			Configuration.Bind("ProjectConfiguration", config);
			services.AddSingleton(config);

            services.AddScoped<IUserService,UserService>();

            services.AddIdentityServer();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, Context dataContext)
        {
            app.UseRouting();

			app.UseHttpsRedirection();

			app.UseForwardedHeaders(new ForwardedHeadersOptions
					{
						ForwardedHeaders = ForwardedHeaders.XForwardedFor | ForwardedHeaders.XForwardedProto
					});

			app.UseAuthorization();

			app.UseCors("MyPolicy");

			dataContext.Database.Migrate();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            app.UseIdentityServer();
        }
    }
}
