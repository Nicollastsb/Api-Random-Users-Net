using Microsoft.EntityFrameworkCore;
using RandomUser.Domain.Interfaces;
using RandomUser.Infra.Data.Context;
using RandomUser.Infra.Data.Repository;
using RandomUser.Service.Services;
using RandomUserCrossCutting;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddDbContext<PostgreSQLContext>(options =>
{
    options.UseNpgsql(builder.Configuration.GetConnectionString("UserConnectionString"));
});
builder.Services.AddTransient<IRandomicUserRepository, RandomicUserRepository>();
builder.Services.AddTransient<IRandomicUserService, RandomicUserService>();
builder.Services.AddTransient<IUserRepository, UserRepository>();
builder.Services.AddTransient<IUserService, UserService>();

builder.Services.AddControllers().AddNewtonsoftJson();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddHttpClient<RandomicUserRepository>();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddAutoMapper(typeof(UserProfile));
builder.Services.AddCors(option => option.AddDefaultPolicy(policy => {
    policy.AllowAnyOrigin();
    policy.AllowAnyMethod();
    policy.AllowAnyHeader();
}));
builder.Services.AddSwaggerGen();

var app = builder.Build();

app.Services.CreateScope().ServiceProvider.GetRequiredService<PostgreSQLContext>().Database.EnsureCreated();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseCors();

app.UseAuthorization();

app.MapControllers();

app.Run();
