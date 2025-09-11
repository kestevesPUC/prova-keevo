using Microsoft.EntityFrameworkCore;
using Microsoft.OpenApi.Models;

var builder = WebApplication.CreateBuilder(args);

builder.Services.AddControllers();

builder.Services.AddCors(options =>
{
    options.AddPolicy("AllowAngular",
        policy => policy.WithOrigins("http://localhost:4200")
                        .AllowAnyHeader()
                        .AllowAnyMethod());
});

builder.Services.AddSwaggerGen(options =>
{
    // Configuração do Swagger para adicionar uma documentação da API
    options.SwaggerDoc("v1", new OpenApiInfo
    {
        Title = "Keevo API",
        Version = "v1",
        Description = "Documentação da API Keevo"
    });
});

builder.Services.AddControllers();

builder.Services.AddEndpointsApiExplorer();

builder.Services.AddDbContext<KeevoDbContext>(options => options.UseNpgsql(builder.Configuration.GetConnectionString("DefaultConnection")));

var app = builder.Build();

app.UseSwagger();

// Habilita o Swagger UI para acessar a documentação
app.UseSwaggerUI(options =>
{
    options.SwaggerEndpoint("/swagger/v1/swagger.json", "Keevo API V1");
    options.RoutePrefix = "swagger";  // Define a URL de acesso ao Swagger UI como a raiz do projeto
});

app.UseCors("AllowAngular");



app.UseHttpsRedirection();
app.UseAuthorization();

app.MapControllers();

app.Run();