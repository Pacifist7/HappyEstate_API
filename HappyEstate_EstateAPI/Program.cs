using HappyEstate_EstateAPI;
using HappyEstate_EstateAPI.Data;
using HappyEstate_EstateAPI.Repository.IRepository;
using HappyEstate_EstateAPI.Repository;
using Microsoft.EntityFrameworkCore;
using Serilog;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddDbContext<ApplicationDbContext>(option =>
{
    option.UseSqlServer(builder.Configuration.GetConnectionString("DefaultSQLConnection"));
});

builder.Services.AddScoped<IEstateRepository, EstateRepository>();
builder.Services.AddScoped<IEstateNumberRepository, EstateNumberRepository>();

builder.Services.AddAutoMapper(typeof(MappingConfig));

builder.Services.AddControllers(option =>
{
    //option.ReturnHttpNotAcceptable = true;
}).AddNewtonsoftJson().AddXmlDataContractSerializerFormatters();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
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
