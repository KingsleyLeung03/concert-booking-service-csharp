using concert_booking_service_csharp.Data;
using Microsoft.AspNetCore.Authentication.OAuth;
using Microsoft.AspNetCore.Authentication;
using Microsoft.EntityFrameworkCore;
using concert_booking_service_csharp.Handlers;

namespace concert_booking_service_csharp;

public class Program
{
    public static void Main(string[] args)
    {
        var builder = WebApplication.CreateBuilder(args);
        builder.Services.AddControllers();

        // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
        builder.Services.AddEndpointsApiExplorer();
        builder.Services.AddSwaggerGen();
        builder.Services
            .AddAuthentication()
            .AddScheme<AuthenticationSchemeOptions, ServiceAuthHandler>("Authentication", null);
        builder.Services.AddDbContext<ServiceDbContext>(options => options.UseSqlite(builder.Configuration["ServiceDbConnection"]));

        builder.Services.AddScoped<IServiceRepo, DbServiceRepo>();

        builder.Services.AddAuthorization(options =>
        {
            options.AddPolicy("UserOnly", policy => policy.RequireClaim("user"));
            options.AddPolicy("AdminOnly", policy => policy.RequireClaim("admin"));
            options.AddPolicy("AuthOnly", policy =>
            {
                policy.RequireAssertion(context => context.User.HasClaim(c => (c.Type == "user" || c.Type == "admin")));
            });
        });

        var app = builder.Build();

        // Configure the HTTP request pipeline.
        if (app.Environment.IsDevelopment())
        {
            app.UseSwagger();
            app.UseSwaggerUI();
        }

        app.UseHttpsRedirection();
        app.UseAuthorization();
        app.MapControllers();
        app.Run();
    }
}
