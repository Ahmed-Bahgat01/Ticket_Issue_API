using BL.Managers;
using BL.Managers.Interfaces;
using DAL.Data.Context;
using DAL.Repos;
using DAL.Repos.Interfaces;
using DAL.UnitOfWork;
using Microsoft.EntityFrameworkCore;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
#region default services
builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
#endregion

#region context
var connectionString = builder.Configuration.GetConnectionString("TicketIssue_ConStr");
builder.Services.AddDbContext<Context>(options => options.UseSqlServer(connectionString));
#endregion

#region repos and UOW
builder.Services.AddScoped<IDepartmentRepo, DepartmentRepo>();
builder.Services.AddScoped<IDeveloperRepo, DeveloperRepo>();
builder.Services.AddScoped<ITicketRepo, TicketRepo>();
builder.Services.AddScoped<IUnitOfWork, UnitOfWork>();
#endregion

#region managers
builder.Services.AddScoped<ITicketManager, TicketManager>();
builder.Services.AddScoped<IDeveloperManager, DeveloperManager>();
builder.Services.AddScoped<IDepartmentsManager, DepartmentManager>();
#endregion



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
