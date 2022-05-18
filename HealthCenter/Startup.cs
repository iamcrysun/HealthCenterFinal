using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.OpenApi.Models;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace HealthCenter
{
    public class Startup
    {
        public Startup(IConfiguration configuration)
        {
            Configuration = configuration;
        }

        private async Task CreateUserRoles(IServiceProvider serviceProvider)
        {
            var roleManager = serviceProvider.GetRequiredService<RoleManager<IdentityRole>>();
            var userManager = serviceProvider.GetRequiredService<UserManager<DAL.Entity.User>>();
            if (await roleManager.FindByNameAsync("admin") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("admin"));
            }
            if (await roleManager.FindByNameAsync("user") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("user"));
            }
            if (await roleManager.FindByNameAsync("doctor") == null)
            {
                await roleManager.CreateAsync(new IdentityRole("doctor"));
            }

            string adminEmail = "reg";
            string adminPassword = "reg";
            if (await userManager.FindByNameAsync(adminEmail) == null)
            {
                DAL.Entity.User admin = new DAL.Entity.User { Email = adminEmail, UserName = adminEmail };
                IdentityResult result = await userManager.CreateAsync(admin, adminPassword);
                if (result.Succeeded)
                {
                    await userManager.AddToRoleAsync(admin, "admin");
                }
            }

        }


        public IConfiguration Configuration { get; }

        // This method gets called by the runtime. Use this method to add services to the container.
        public void ConfigureServices(IServiceCollection services)
        {
            var connection =
            Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<DAL.HealthyContext>(options =>
            options.UseSqlServer(connection));
            services.AddIdentity<DAL.Entity.User, IdentityRole>().AddEntityFrameworkStores<DAL.HealthyContext>();
            services.Configure<IdentityOptions>(options =>
            {
                options.Password.RequireDigit = false;
                options.Password.RequireLowercase = false;
                options.Password.RequiredLength = 3;
                options.Password.RequireUppercase = false;
                options.Password.RequireNonAlphanumeric = false;
            });
            services.AddControllers();
            services.AddMvc(options => options.EnableEndpointRouting = false).AddNewtonsoftJson(options => {
            options.SerializerSettings.ReferenceLoopHandling = ReferenceLoopHandling.Ignore;
            });

            string[] s = new string[] { "http://localhost:8080", "http://localhost:8081", "http://localhost:5000", "http://localhost:8083", "http://localhost:8084", "http://localhost:8085" };
            services.AddCors(options =>
            {
                options.AddDefaultPolicy(
                    builder =>
                    {
                        builder.AllowCredentials().WithOrigins(s)
                                .AllowAnyHeader()
                                .AllowAnyMethod();

                    });
            });

            services.ConfigureApplicationCookie(options =>
            {
                options.Cookie.Name = "SimpleWebApp";
                options.LoginPath = "/";
                options.AccessDeniedPath = "/";
                options.LogoutPath = "/";
                options.Events.OnRedirectToLogin = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
                options.Events.OnRedirectToAccessDenied = context =>
                {
                    context.Response.StatusCode = 401;
                    return Task.CompletedTask;
                };
            });

            services.AddSwaggerGen(c =>
            {
                c.SwaggerDoc("v1", new OpenApiInfo { Title = "HealthCenter", Version = "v1" });
            });
            
        }

        // This method gets called by the runtime. Use this method to configure the HTTP request pipeline.
        public void Configure(IApplicationBuilder app, IWebHostEnvironment env, IServiceProvider services)
        {
            app.UseCors();
            app.Use((context, next) =>
            {
                context.Response.Headers["Access-Control-Allow-Credentials"] = "*";
                context.Response.Headers["Access-Control-Allow-Origin"] = "*";
                context.Response.Headers["Access-Control-Allow-Headers"] = "Origin, X-Requested-With, Content-Type, Accept";
                context.Response.Headers["Access-Control-Allow-Methods"] = "PUT, POST, GET, DELETE, OPTIONS";
                return next.Invoke();
            });
            app.UseAuthentication();
            
            app.UseDefaultFiles();
            app.UseStaticFiles();
            app.UseMvc();
            if (env.IsDevelopment())
            {
                app.UseDeveloperExceptionPage();
                app.UseSwagger();
                app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "HealthCenter"));
            }

            app.UseRouting();
            app.UseAuthorization();

           

            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllers();
            });

            CreateUserRoles(services).Wait();
        }
    }
}
