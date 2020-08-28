using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using WebApplicationSyscompsa.Models;

namespace WebApplicationSyscompsa
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
            services.AddControllers();

           // var connectionB = @"Data Source = 181.196.189.58,59925\\SQLEXPRESS; Initial Catalog = SQLOSTRATEK; Persist Security Info = True; User ID = sa; Password = Rootpass1";
           // var connectionB = @"Data Source = JOSE\SQLEXPRESS; Initial Catalog = CIA01; Persist Security Info = True; User ID = sa; Password = a";
              var connectionB = @"Data Source = CIA01-Web.mssql.somee.com;" +
                               "Initial Catalog = CIA01-Web; Persist Security Info = True;" +
                               "User ID = AkaliServer90_SQLLogin_1; Password = cveb2x36w4;";
           // var connectionB = "Server=tcp:negfar.database.windows.net,1433;Initial Catalog=NegFarBd;Persist Security Info=False;User ID=NegFar;Password={your_password};MultipleActiveResultSets=False;Encrypt=True;TrustServerCertificate=False;Connection Timeout=30;";
           // var connectionB = @"Data Source = syswebservice\sqlexpress\\SQLEXPRESS; Initial Catalog = WEBCIA01; Persist Security Info = True; User ID = sa; Password = Rootpass1";

           services.AddDbContext<AppDbContext>(options => options.UseSqlServer(connectionB));
           services.AddControllersWithViews().AddNewtonsoftJson(options =>
           options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore);            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {

            app.UseCors(builder => builder.WithOrigins("http://localhost:58726", "http://www.syscompsa.somee.com/")
            .AllowAnyHeader().AllowAnyMethod().AllowAnyOrigin());

            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
