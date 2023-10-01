using System.Text;
using System.Text.Json.Serialization;
using Api.Filters;
using EasyBooking.Appplication;
using EasyBooking.Domain;
using EasyBooking.Infrastructure;
using FluentValidation;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;

var SpecificOrigins = "_specificOrigins";
var builder = WebApplication.CreateBuilder(args);

builder.Services.AddCors(options =>
{
    options.AddPolicy(SpecificOrigins,
                        policy =>
                        {
                            policy.WithOrigins("http://localhost:4200")
                                                .AllowAnyHeader()
                                                .AllowAnyMethod();
                        });
});

builder.Services.AddControllers(options => 
{
    options.Filters.Add<ErrorFilter>(int.MaxValue -10);
})
.AddJsonOptions(opts => {
    var enumConverter = new JsonStringEnumConverter();
    opts.JsonSerializerOptions.Converters.Add(enumConverter);
});

builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();

builder.Services.AddSwaggerGen(c =>
{
    c.SwaggerDoc("v1", new OpenApiInfo { Title = "EasyBooking.API", Version = "v1" });

    c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme()
    {
        Name = "Authorization",
        Type = SecuritySchemeType.ApiKey,
        Scheme = "Bearer",
        BearerFormat = "JWT",
        In = ParameterLocation.Header,
        Description = "JWT Authorization header with scheme Bearer."
    });

    c.AddSecurityRequirement(new OpenApiSecurityRequirement
    {
        {
            new OpenApiSecurityScheme
            {
                Reference = new OpenApiReference
                {
                    Type =ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            Array.Empty<string>()
        }
    });
}).AddApiVersioning(options =>
{
    options.ReportApiVersions = true;
    options.AssumeDefaultVersionWhenUnspecified = true;
    options.DefaultApiVersion = new ApiVersion(1, 0);
}).AddVersionedApiExplorer(p => 
{
    p.GroupNameFormat = "'v'VVV";
    p.SubstituteApiVersionInUrl = true;
});


builder.Services.AddAuthentication(JwtBearerDefaults.AuthenticationScheme)
    .AddJwtBearer(options =>
    {    
        options.TokenValidationParameters = new TokenValidationParameters
        {
            ValidateIssuer = true,
            ValidateAudience = true,
            ValidateLifetime = true,
            ValidateIssuerSigningKey = true,

            ValidIssuer = builder.Configuration["Jwt:Issuer"],
            ValidAudience = builder.Configuration["Jwt:Audience"],
            IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(builder.Configuration["Jwt:Key"] ?? ""))
        };
    });

    builder.Services.AddHealthChecks();

builder.Services.AddDbContext<EasyBookingDbContext>(options => options.UseSqlServer(builder.Configuration.GetConnectionString("DefaultConnection")));

builder.Services.AddScoped<IAuthService, AuthService>();
builder.Services.AddScoped<ILoginUser, LoginUser>();

builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<ICreateUser, CreateUser>();
builder.Services.AddScoped<IGetUserQuery, GetUserQuery>();

builder.Services.AddScoped<IUserRoleRepository, UserRoleRepository>();
builder.Services.AddScoped<ICreateUserRole, CreateUserRole>();
builder.Services.AddScoped<IGetUserRoleQuery, GetUserRoleQuery>();

builder.Services.AddScoped<IEstablishmentRepository, EstablishmentRepository>();
builder.Services.AddScoped<IGetEstablishmentQuery, GetEstablishmentQuery>();
builder.Services.AddScoped<ICreateEstablishment, CreateEstablishment>();

builder.Services.AddScoped<IGameSpaceRepository, GameSpaceRepository>();
builder.Services.AddScoped<IGetGameSpaceQuery, GetGameSpaceQuery>();
builder.Services.AddScoped<ICreateGameSpace, CreateGameSpace>();

builder.Services.AddScoped<IWeekDayRepository, WeekDayRepository>();
builder.Services.AddScoped<ICreateWeekDay, CreateWeekDay>();
builder.Services.AddScoped<IGetWeekDayQuery, GetWeekDayQuery>();
builder.Services.AddScoped<IFinishWeekDay, FinishWeekDay>();
builder.Services.AddScoped<ICancellWeekDay, CancellWeekDay>();

builder.Services.AddScoped<IErrorBagService, ErrorBagService> ();
builder.Services.AddTransient<IValidator<CreateUserRoleRequest>, UserRoleSpecifications>();
builder.Services.AddTransient<IValidator<CreateUserRequest>, UserSpecifications>();
builder.Services.AddTransient<IValidator<CreateEstablishmentRequest>, EstablishmentSpecifications>();
builder.Services.AddTransient<IValidator<CreateGameSpaceRequest>, GameSpaceSpecifications>();
builder.Services.AddTransient<IValidator<CreateWeekDayRequest>, WeekDaySpecifications>();
builder.Services.AddTransient<IValidator<Guid>, GuidSpecifications>();

var app = builder.Build();

app.UseSwagger();
app.UseSwaggerUI(c => c.SwaggerEndpoint("/swagger/v1/swagger.json", "EasyBooking.Api V1"));

app.UseCors(SpecificOrigins);

app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();

app.MapControllers();

app.Run();
