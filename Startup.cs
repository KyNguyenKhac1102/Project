using Microsoft.AspNetCore.Builder;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.HttpsPolicy;
using Microsoft.AspNetCore.SpaServices.ReactDevelopmentServer;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Microsoft.Extensions.Hosting;


using Project.Context;
using Microsoft.EntityFrameworkCore;
using Project.Services;
using Project.Repositories;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using Microsoft.OpenApi.Models;
using System.Collections.Generic;

namespace project
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

            string connectionString = Configuration.GetConnectionString("DefaultConnection");
            services.AddDbContext<ProjectContext>(options => options.UseSqlServer(connectionString));

            services.AddAuthentication(x =>
            {
                x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
        .AddJwtBearer(options =>
        {
            options.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuer = true,
                ValidateAudience = true,
                ValidateLifetime = true,
                ValidateIssuerSigningKey = true,
                ValidIssuer = Configuration["Jwt:Issuer"],
                ValidAudience = Configuration["Jwt:Issuer"],
                IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(Configuration["Jwt:Key"]))
            };
        });

            services.AddCors(o => o.AddPolicy("MyPolicy", builder =>
             {
                 builder.WithOrigins(new[] { "https://localhost:3000", "https://localhost:5000", "https://localhost:5001" })
                     .AllowAnyMethod()
                     .AllowAnyHeader()
                     .AllowCredentials();
             }));

            services.AddScoped<IUserRepository, UserRepository>();
            services.AddScoped<ITruongRepository, TruongRepository>();
            services.AddScoped<IStudentInfoRepository, StudentInfoRepository>();

            services.AddScoped<IUserService, UserService>();
            services.AddScoped<ITruongService, TruongService>();
            services.AddScoped<IStudentInfoService, StudentInfoService>();
            services.AddControllersWithViews();


            services.AddSwaggerGen();
            //             services.AddSwaggerGen(c =>
            //   {
            //   c.SwaggerDoc("v1", new OpenApiInfo { Title = "You api title", Version = "v1" });
            //   c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
            //   {
            //       Description = @"JWT Authorization header using the Bearer scheme. \r\n\r\n 
            //                   Enter 'Bearer' [space] and then your token in the text input below.
            //                   \r\n\r\nExample: 'Bearer 12345abcdef'",
            //       Name = "Authorization",
            //       In = ParameterLocation.Header,
            //       Type = SecuritySchemeType.ApiKey,
            //       Scheme = "Bearer"
            //   });

            //   c.AddSecurityRequirement(new OpenApiSecurityRequirement()
            //   {
            //     {
            //       new OpenApiSecurityScheme
            //       {
            //         Reference = new OpenApiReference
            //           {
            //             Type = ReferenceType.SecurityScheme,
            //             Id = "Bearer"
            //           },
            //           Scheme = "oauth2",
            //           Name = "Bearer",
            //           In = ParameterLocation.Header,

            //         },
            //         new List<string>()
            //       }
            //     });

            //   });

            // In production, the React files will be served from this directory
            services.AddSpaStaticFiles(configuration =>
            {
                configuration.RootPath = "ClientApp/build";
            });
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

            app.UseSwagger();

            app.UseHttpsRedirection();
            app.UseStaticFiles();
            app.UseSpaStaticFiles();

            app.UseSwaggerUI(c =>
        {
            c.SwaggerEndpoint("/swagger/v1/swagger.json", "My API V1");
        });

            app.UseRouting();
            app.UseCors("MyPolicy");

            app.UseAuthentication();
            app.UseAuthorization();
            app.UseEndpoints(endpoints =>
            {
                endpoints.MapControllerRoute(
                    name: "default",
                    pattern: "{controller}/{action=Index}/{id?}");
            });

            app.UseSpa(spa =>
            {
                spa.Options.SourcePath = "ClientApp";

                if (env.IsDevelopment())
                {
                    spa.UseReactDevelopmentServer(npmScript: "start");
                }
            });
        }
    }
}
