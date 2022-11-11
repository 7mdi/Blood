using BloodDonor.BL.Interface;
using BloodDonor.BL.Mapper;
using BloodDonor.BL.Ropository;
using BloodDonor.DAL.DataBase;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);






//ConnectionString
builder.Services.AddDbContext<ApplicationDbContext>(options =>
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

//Mapper
builder.Services.AddAutoMapper(x => x.AddProfile(new DomainProfile()));

//Take one instance for each user
builder.Services.AddScoped<IDonorRep, DonorRep>();
builder.Services.AddScoped<INeederRep, NeederRep>();

// Add services to the container.

builder.Services.AddControllers();
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
