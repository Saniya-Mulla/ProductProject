

using Microsoft.EntityFrameworkCore;
using MvcTaskManager.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddMvc();
builder.Services.AddCors(options => options.AddPolicy(name: "ProjectsOrigin",
  policy =>
  {
      policy.WithOrigins("http://localhost:4200").AllowAnyMethod().AllowAnyHeader();
  }));
builder.Services.AddDbContext<DataContext>(options =>
{
    options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection"));
});

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors("ProjectsOrigin");

app.UseAuthorization();

app.MapControllers();

app.Run();
