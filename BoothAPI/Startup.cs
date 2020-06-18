using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.EntityFrameworkCore;
using IBoothDataAccess;
using BoothDataAccess;
using IBoothService;
using BoothService;

namespace BoothAPI
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

            services.AddDbContext<BoothManageContext>(options =>
            options.UseSqlServer(Configuration.GetConnectionString("BoothConnection")));
            
            services.AddScoped<IBoothManageContext, BoothDataAccess.BoothManageContext>();
            services.AddScoped<IRepositoryFactory, RepositoryFactory>();
            services.AddScoped<IShow, Show>();
            services.AddScoped<IRbac, Rbac>();


            // ���ÿ���������������Դ
            services.AddCors(options =>
            {
                // Policy ���Q CorsPolicy ����ӆ�ģ������Լ���
                options.AddPolicy("getd", policy =>
                {
                    // �O�����S����ā�Դ���ж�����Ԓ������ `,` ���_
                    policy.WithOrigins("http://localhost:52229", "http://localhost:53979")
                            .AllowAnyHeader()
                            .AllowAnyMethod()
                            .AllowCredentials();
                });
            });
            services.AddControllers();
            


        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env)
        {
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
            }

            app.UseRouting();

            app.UseAuthorization();
            app.UseCors("getd");
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });
        }
    }
}
