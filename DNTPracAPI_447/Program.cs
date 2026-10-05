using DAL.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Options;
using Repository.Abstraction;
using Repository.Implementation;
using Serilog;
using System.Diagnostics;

var builder = WebApplication.CreateBuilder(args);

Log.Logger = new LoggerConfiguration()
    .ReadFrom.Configuration(builder.Configuration)
    .CreateLogger();
builder.Host.UseSerilog();
// Add services to the container.
builder.Services.AddControllers().AddNewtonsoftJson(b =>
{
    b.SerializerSettings.ReferenceLoopHandling = Newtonsoft.Json.ReferenceLoopHandling.Ignore;
}
);

builder.Services.AddControllers().AddJsonOptions(p =>
{
    //Camel casing is not enabled in c# model class
    p.JsonSerializerOptions.PropertyNamingPolicy = null;
 });

// Learn more about configuring OpenAPI at https://aka.ms/aspnet/openapi
builder.Services.AddOpenApi();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddTransient<IProductRepository, ProductRepository>();
builder.Services.AddTransient<ICustom, Custom>();
builder.Services.AddDbContext<AppDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DbConnection"));
    option.LogTo(x => Debug.WriteLine(x));
});
builder.Services.AddCors(policy =>
{
    policy.AddPolicy("myPolicy", option =>
    {
        option.AllowAnyOrigin();
        option.AllowAnyHeader();
        option.AllowAnyMethod();
        //option.WithOrigins("https://localhost:7009");//for specific origin
    });
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.MapOpenApi();
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();
app.UseCors("myPolicy");

app.UseAuthorization();


app.MapControllers();

app.Run();
