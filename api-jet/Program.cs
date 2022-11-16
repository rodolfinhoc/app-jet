using api;
using api.Data;
using api.Services;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System.Text.Json.Serialization;

var builder = WebApplication.CreateBuilder(args);

//Inicia a API
StartAPI(builder);

void StartAPI(WebApplicationBuilder builder)
{
    ConfigureAuthentication(builder);
    ConfigureMvc(builder);
    ConfigureServices(builder);

    var app = builder.Build();

    //Configura Autorização e Autenticação
    app.UseAuthentication(); // Quem você é?
    app.UseAuthorization();  // O que você pode fazer?

    app.UseCors("CorsPolicy");
    //Configura para API considerar controller para rotas
    app.MapControllers();
    //Configura para adicionar o Swagger para documentação
    app.UseSwagger();
    app.UseSwaggerUI(options =>
    {
        options.SwaggerEndpoint("/swagger/v1/swagger.json", "Documentação API JET");
        
    });
    //Inicia o programa
    app.Run();
}

void ConfigureAuthentication(WebApplicationBuilder builder)
{
    // Configura��o do Token
    var key = Encoding.ASCII.GetBytes(Configuration.JwtKey);
    // Autenticação e Autorização
    builder.Services.
        AddAuthentication(x =>
        {
            x.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
            x.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
        }).
        AddJwtBearer(x =>
        {
            x.TokenValidationParameters = new TokenValidationParameters
            {
                ValidateIssuerSigningKey = true,
                IssuerSigningKey = new SymmetricSecurityKey(key),
                ValidateIssuer = false,
                ValidateAudience = false,
            };
        });
}

void ConfigureMvc(WebApplicationBuilder builder)
{
    //Adiciona funcionalidade da gestão por Controller
    builder
        .Services
       .AddCors(options =>
       {
           options.AddPolicy("CorsPolicy", builder => builder
            .AllowAnyOrigin()
            .AllowAnyMethod()
            .AllowAnyHeader());
       })
        .AddMemoryCache()   //Gestão do cache
        .AddControllers()
         .AddJsonOptions(x =>
         {
             x.JsonSerializerOptions.ReferenceHandler = ReferenceHandler.IgnoreCycles;
             x.JsonSerializerOptions.DefaultIgnoreCondition = JsonIgnoreCondition.WhenWritingDefault;
         })
        .ConfigureApiBehaviorOptions(options => {
            options.SuppressModelStateInvalidFilter = true;
        });
}

void ConfigureServices(WebApplicationBuilder builder)
{
    builder.Services.AddDbContext<DataBaseContext>();
    builder.Services.AddTransient<TokenService>();
    builder.Services.AddTransient<FtpService>();
    builder.Services.AddSwaggerGen(options =>
    {
        options.SwaggerDoc("v1", new Microsoft.OpenApi.Models.OpenApiInfo
        {
            Title = "API - JET",
            Description = "API - JET",
            Version = "v1"
        });

    });
}


