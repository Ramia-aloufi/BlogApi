using BlogApi.src.DB;
using BlogApi.src.Mappers;
using Microsoft.EntityFrameworkCore;
using Npgsql;

var builder = WebApplication.CreateBuilder(args);

var _config = builder.Configuration;
var DefaultConnection = new NpgsqlDataSourceBuilder($"Server={_config["Db:Server"]};User Id={_config["Db:Username"]};Database={_config["Db:Database"]};Password={_config["Db:Password"]};Port={_config["Db:Port"]}").Build();

builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
builder.Services.AddAutoMapper(typeof(MapperConfig));
builder.Services.AddControllers();
builder.Services.AddDbContext<DBContext>(option=>{
option.UseNpgsql(DefaultConnection);
});
var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.MapControllers();
app.Run();
