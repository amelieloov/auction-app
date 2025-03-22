using GrupparbeteAuktion.Core.Interfaces;
using GrupparbeteAuktion.Core.Services;
using GrupparbeteAuktion.Domain.Models;
using GrupparbeteAuktion.Data.Interfaces;
using GrupparbeteAuktion.Data.Repos;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using Microsoft.EntityFrameworkCore;
using System.Text;
using GrupparbeteAuktion.Data.DataModels;
using GrupparbeteAuktion.Domain.Profiles;
using GrupparbeteAuktion.Api.Extensions;
using Microsoft.Extensions.Options;
using Microsoft.AspNetCore.Hosting.Internal;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddSwaggerExtended();

//builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(AuctionProfile).Assembly, typeof(BidProfile).Assembly, typeof(UserProfile).Assembly);
builder.Services.AddControllers();
builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll", policy =>
    {
        policy.AllowAnyOrigin()
              .AllowAnyHeader()
              .AllowAnyMethod();
    });
});

var connectionString = builder.Configuration.GetConnectionString("AuctionDb"); //Tar Constring fr�n appsettings.json
builder.Services.AddDbContext<AppDbContext>(options =>
    options.UseSqlServer(connectionString));

builder.Services.AddScoped<IUserRepo, UserRepo>();
builder.Services.AddScoped<IUserService, UserService>();
builder.Services.AddScoped<IAuctionDBContext, AuctionDBContext>();
builder.Services.AddScoped<IAuctionRepo, AuctionRepo>();
builder.Services.AddScoped<IAuctionService, AuctionService>();
builder.Services.AddScoped<IBidRepo, BidRepo>();
builder.Services.AddScoped<IBidService, BidService>();

builder.Services.AddAuthentication(opt =>
{
    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(opt =>
{
    opt.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"]))
    };

    opt.Events = new JwtBearerEvents
    {
        // Handle token extraction from cookies if the token is not in the Authorization header
        OnMessageReceived = context =>
        {
            // Check if the token is in cookies and set it in the Authorization header
            var token = context.Request.Cookies["AuthToken"];
            if (!string.IsNullOrEmpty(token))
            {
                context.Token = token;
            }
            return Task.CompletedTask;
        }
    };
});

var app = builder.Build();

app.UseStaticFiles();

app.UseSwaggerExtended();
app.UseCors("AllowAll");


app.UseRouting();

app.UseAuthentication();
app.UseAuthorization();


app.UseEndpoints(endpoints =>
{
    endpoints.MapControllers(); 
});

app.Run(); 
