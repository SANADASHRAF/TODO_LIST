using Microsoft.AspNetCore.HttpOverrides;
using System.Security.Cryptography;
using TodoListAPI.Extension;

var builder = WebApplication.CreateBuilder(args);

builder.Services.ConfigureRepositoryManager();
builder.Services.ConfigureServiceManager();
builder.Services.ConfigureSqlContext(builder.Configuration);


builder.Services.ConfigureCors();
builder.Services.AddAutoMapper(typeof(Program));
builder.Services.AddControllers().AddApplicationPart(typeof(TodoListAPI.Presentation.AssemblyReference).Assembly);

builder.Services.AddAuthentication();
builder.Services.ConfigureJWT(builder.Configuration);


builder.Services.AddEndpointsApiExplorer();
builder.Services.AddOpenApi();
builder.Services.AddSwaggerGen();


var app = builder.Build();

if (app.Environment.IsProduction() || app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
    app.UseStaticFiles();
}

app.UseRouting();

app.UseCors("CorsPolicy");

app.UseHttpsRedirection();

app.UseAuthentication();
app.UseAuthorization();


app.UseForwardedHeaders(new ForwardedHeadersOptions
{
    ForwardedHeaders = ForwardedHeaders.All
});


app.MapControllers();

app.Run();