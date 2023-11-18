using System.Text;
using BusModelLibrary;
using BusTicketingWebApplication.Contexts;
using BusTicketingWebApplication.Interfaces;
using BusTicketingWebApplication.Models;
using BusTicketingWebApplication.Repositories;
using BusTicketingWebApplication.Reposittories;
using BusTicketingWebApplication.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.Build.Execution;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

namespace BusTicketingWebApplication
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.
            builder.Services.AddRazorPages();
             builder.Services.AddControllers();
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(opt =>
            {
                opt.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Name = "Authorization",
                    Type = SecuritySchemeType.Http,
                    Scheme = "Bearer",
                    BearerFormat = "JWT",
                    In = ParameterLocation.Header,
                    Description = "JWT Authorization header using the Bearer scheme."
                });

                opt.AddSecurityRequirement(new OpenApiSecurityRequirement
                 {
                     {
                           new OpenApiSecurityScheme
                             {
                                 Reference = new OpenApiReference
                                 {
                                     Type = ReferenceType.SecurityScheme,
                                     Id = "Bearer"
                                 }
                             },
                             new string[] {}

                     }
                 });
            });

            builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
                .AddJwtBearer(options =>
                {
                    options.TokenValidationParameters = new TokenValidationParameters
                    {
                        ValidateIssuer = false,
                        ValidateAudience = false,
                        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["SecretKey"])),
                        ValidateIssuerSigningKey = true
                    };
                });

            builder.Services.AddDbContext<TicketingContext>(opts =>
            {
                opts.UseSqlServer(builder.Configuration.GetConnectionString("conn"));
            });

            builder.Logging.AddLog4Net();

            builder.Services.AddScoped<IUserRepository, UserRepository>();
            builder.Services.AddScoped<IBusRepository, BusRepository>();
            builder.Services.AddScoped<IBusRouteRepository, BusRouteRepository>();
            builder.Services.AddScoped<IUserService, UserService>();
            builder.Services.AddScoped<ITokenService, TokenService>();
            builder.Services.AddScoped<IBusService, BusService>();
            builder.Services.AddScoped<IBusRouteService, BusRouteService>();
            var app = builder.Build();

            // Configure the HTTP request pipeline.
            if (app.Environment.IsDevelopment())
            {
                app.UseSwagger();
                app.UseSwaggerUI();
                //app.UseExceptionHandler("/Home/Error");
            }
            app.UseStaticFiles();
            app.UseRouting();

            app.UseAuthentication();
            app.UseAuthorization();

            app.MapControllerRoute(
                name: "default",
                pattern: "{controller=Home}/{action=Index}/{id?}");

            app.Run();
        }
    }
}