using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Contract;
using TshirtOrderPlacingPortal.Infrastructure.Configuration.Repository;
using TshirtOrderPlacingPortal.Infrastructure.Data;
using TshirtOrderPlacingPortal.Service;


namespace TshirtOrderPlacingPortal.Core
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
            services.AddCors();
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.WithOrigins("http://localhost:3000")
                                            .AllowAnyHeader()
                                            .AllowAnyMethod();
                    });
            });

            services.AddDbContext<DBContext>(options =>
            {
                options.UseSqlServer(Configuration.GetConnectionString("WebApiDatabase"));
            });

            services.AddControllers();
            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "TshirtOrderPlacingPortal.Core", Version = "v1" });
            });

            services.AddTransient<IUnitOfWork, UnitOfWork>();
            services.AddTransient<ITshirt, TshirtService>();
            services.AddTransient<IStyle, StyleService>();
            services.AddTransient<ISize, SizeService>();
            services.AddTransient<IFile, FileService>();
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "TshirtOrderPlacingPortal.Core v1"));
            }
            app.UseCors();
            app.UseCors(builder =>
            {
                builder
                .AllowAnyOrigin()
                .AllowAnyMethod()
                .AllowAnyHeader();
            });
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
