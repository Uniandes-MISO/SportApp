using SportApp.Core.Interfaces;
using SportApp.Core.Services;
using SportApp.Infrastructure.Persistence;
using SportApp.Infrastructure.Persistence.Config;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.AddSingleton(builder.Configuration.GetSection(PostgresSettings.SectionName).Get<PostgresSettings>());
builder.Services.AddScoped<IUserService, UserService>();

// register application DB context
builder.Services.AddAppDbContext(builder.Configuration);

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}



// run DB migration on application start
app.RunDbContextMigrations();


app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();



app.Run();
