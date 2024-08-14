using System.Text;
using System.Text.Json.Serialization;
using BlogApi.src.DB;
using BlogApi.src.DTOs;
using BlogApi.src.Mappers;
using BlogApi.src.Models;
using BlogApi.src.Repository;
using BlogApi.src.Repository.Generic;
using BlogApi.src.Services;
using BlogApi.src.Services.Implementations;
using BlogApi.src.Services.Interfaces;
using Microsoft.AspNetCore.Authentication.JwtBearer;

using Microsoft.EntityFrameworkCore;
using Microsoft.IdentityModel.Tokens;
using Microsoft.OpenApi.Models;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var _config = builder.Configuration;

var dataSourceBuilder = new NpgsqlDataSourceBuilder($"Server={_config["Db:Server"]};User Id={_config["Db:Username"]};Database={_config["Db:Database"]};Password={_config["Db:Password"]};Port={_config["Db:Port"]}");
dataSourceBuilder.MapEnum<Role>();

var key = Encoding.ASCII.GetBytes(builder.Configuration.GetValue<string>("JWTSecret"));

builder.Services.Configure<EmailSettings>(builder.Configuration.GetSection("EmailSettings"));


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

builder.Services.AddTransient<IEmailSender, EmailSender>();
builder.Services.AddScoped<IUserService, UserService>();

builder.Services.AddScoped<IService<CategoryDTO>, Service<Category, CategoryDTO>>();
builder.Services.AddScoped<IService<CommentDTO>, Service<Comment, CommentDTO>>();
builder.Services.AddScoped<IService<PostDTO>, Service<Post, PostDTO>>();
builder.Services.AddScoped<IService<UserDTO>, Service<User, UserDTO>>();
builder.Services.AddScoped(typeof(IRepository<>), typeof(Repository<>));

builder.Services.AddControllers().AddJsonOptions(x =>
                x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles);;
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
var dataSource = dataSourceBuilder.Build();

builder.Services.AddDbContext<DBContext>(option =>
{
    option.UseNpgsql(dataSource);
    
});





var app = builder.Build();

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
