using BusinessLayer.AutoMapperProfile;
using BusinessLayer.Interfaces;
using BusinessLayer.Services;
using DataAccess.Data;
using DataAccess.Repositories;
using DataAccess.Repository;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddDbContext<Team04DbContext>(options => options.UseSqlServer("DefaultConnection"));
builder.Services.AddScoped(typeof(IGenericRepository<>), typeof(GenericRepository<>));
// builder.Services.AddScoped<IBaseService<PremiseDto>, BaseService<PremiseDto, Premise>>();
builder.Services.AddScoped<IPremiseService, PremiseService>();
builder.Services.AddScoped<IPremiseRepository, PremiseRepository>();
builder.Services.AddScoped<IFacilityRepository, FacilityRepository>();
builder.Services.AddScoped<IFacilityService, FacilityIService>();
builder.Services.AddScoped<IMinorWorkService, MinorWorkService>();
builder.Services.AddScoped<IVolunteeringService, VolunteeringService>();
builder.Services.AddAutoMapper(typeof(AutoMapperProfile));

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