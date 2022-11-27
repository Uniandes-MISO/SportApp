using SportApp.Api.Extensions;
using SportApp.Infrastructure.Persistence;

var builder = WebApplication.CreateBuilder(args);

//LogManager.LoadConfiguration(string.Concat(Directory.GetCurrentDirectory(), "/nlog.config"));
//LoggerManager logger = new LoggerManager();

// Add services to the container.
builder.Services.RegisterDependencies();
builder.Services.ConfigureMapping();
//builder.Services.ConfigureLoggerService();

// register application DB context
builder.Services.AddAppDbContext(builder.Configuration);

builder.Services.AddAuthentication();
builder.Services.ConfigureIdentity();
builder.Services.ConfigureJWT(builder.Configuration);

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();

builder.Services.ConfigureSwagger();
builder.Services.AddSwaggerGen();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAll",
        builder =>
        {
            builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader();
        });
});

//builder.Services.AddSwaggerGen();
//builder.Services.AddSwaggerGen(options =>
//{
//    options.SwaggerDoc("V1", new OpenApiInfo
//    {
//        Version = "V1",
//        Title = "WebAPI",
//        Description = "SportApp WebAPI"
//    });
//    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
//    {
//        Scheme = "Bearer",
//        BearerFormat = "JWT",
//        In = ParameterLocation.Header,
//        Name = "Authorization",
//        Description = "Bearer Authentication with JWT Token",
//        Type = SecuritySchemeType.Http
//    });
//    options.AddSecurityRequirement(new OpenApiSecurityRequirement
//    {
//        {
//            new OpenApiSecurityScheme
//            {
//                Reference = new OpenApiReference
//                {
//                    Id = "Bearer",
//                    Type = ReferenceType.SecurityScheme
//                }
//            },
//            new List<string>()
//        }
//    });
//});

//builder.Services.AddSingleton(builder.Configuration.GetSection(PostgresSettings.SectionName).Get<PostgresSettings>());
//builder.Services.AddScoped<IUserService, ActivityService>();
//builder.Services.AddDbContext<AppDbContext>();

// register application DB context
//builder.Services.AddAppDbContext(builder.Configuration);

//builder.Services.AddAuthentication(opt => {
//    opt.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
//    opt.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
//})
//    .AddJwtBearer(options =>
//    {
//        options.TokenValidationParameters = new TokenValidationParameters
//        {
//            ValidateIssuer = true,
//            ValidateAudience = true,
//            ValidateLifetime = true,
//            ValidateIssuerSigningKey = true,
//            ValidIssuer = ConfigurationManager.AppSetting["JWT:ValidIssuer"],
//            ValidAudience = ConfigurationManager.AppSetting["JWT:ValidAudience"],
//            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(ConfigurationManager.AppSetting["JWT:Secret"]))
//        };
//    });

AppContext.SetSwitch("Npgsql.EnableLegacyTimestampBehavior", true);
//AppContext.SetSwitch("Npgsql.DisableDateTimeInfinityConversions", true);

var app = builder.Build();

app.MapGet("/", () => "Run SportApp Api");

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    /*app.UseSwaggerUI(options => {
        options.SwaggerEndpoint("/swagger/V1/swagger.json", "SportApp WebAPI");
    });*/
}

// run DB migration on application start
//app.RunDbContextMigrations();

//app.UseHttpsRedirection();
//app.UseAuthorization();
//app.MapControllers();

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();
app.UseCors(x => x
        .AllowAnyOrigin()
        .AllowAnyMethod()
        //.SetIsOriginAllowed(origin => true) // allow any origin
        .AllowAnyHeader());

app.Run();