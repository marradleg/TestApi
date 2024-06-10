using Microsoft.EntityFrameworkCore;
using MWCodeReview.Interfaces;
using MWCodeReview.Models;
using MWCodeReview.Services;
using NLog.Web;
using System.Security;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers().AddNewtonsoftJson(options =>
              options.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore
              );
builder.Services.AddDbContext<MW_DB_TESTContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("BoardConectionString")));

builder.Services.AddScoped<IUser, UserService>();

builder.Host.UseNLog();

builder.Services.AddEndpointsApiExplorer();


builder.Services.AddSwaggerGen();


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
