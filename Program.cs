using System.Text;
using BlogApi.src.DB;
using BlogApi.src.Mappers;
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.CodeAnalysis.Options;
using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);
var _config = builder.Configuration;
var DefaultConnection = new NpgsqlDataSourceBuilder($"Server={_config["Db:Server"]};User Id={_config["Db:Username"]};Database={_config["Db:Database"]};Password={_config["Db:Password"]};Port={_config["Db:Port"]}").Build();
var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecret"));

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
    {
        Description = "JWT Authorization header using bearer schema. Enter Bearer [space] in the text input.Example : Bearer qqwwee",
        Name = "Authorization",
        In = ParameterLocation.Header,
        Scheme = "Bearer"
    });
    options.AddSecurityRequirement(new OpenApiSecurityRequirement(){
{        new OpenApiSecurityScheme{
            Reference = new OpenApiReference
            {
                Id = "Bearer",
                Type = ReferenceType.SecurityScheme

            },
            Scheme = "oauth2",
            Name = "Bearer",
            In = ParameterLocation.Header
        },
        new List<string>()}
    });
});
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddControllers();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));
builder.Services.AddTransient<IPostRepository, PostRepository>();
builder.Services.AddCors(option => option.AddPolicy("TesPolicy", policy =>
policy.AllowAnyHeader().AllowAnyOrigin().AllowAnyMethod()
));
builder.Services.AddAuthentication(option =>
{
    option.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    option.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
    //I can identify multiple AddJwtBearer with different names
}).AddJwtBearer(option =>
{
    //Validation criteria
    //option.RequireHttpsMetadata = false;
    option.SaveToken = true;
    option.TokenValidationParameters = new TokenValidationParameters()
    {
        ValidateIssuerSigningKey = true,
        //if i want validate specific issuer make it true and identify valid issuer
        ValidateIssuer = false,
        IssuerSigningKey = new SymmetricSecurityKey(key),
        //if i want validate specific Audience make it true and identify valid Audience
        ValidateAudience = false,
    };
});
builder.Services.AddDbContext<DBContext>(option =>
{
    option.UseNpgsql(DefaultConnection);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}
app.UseHttpsRedirection();
app.UseCors("TesPolicy");
app.UseAuthorization();
app.MapControllers();
app.Run();
