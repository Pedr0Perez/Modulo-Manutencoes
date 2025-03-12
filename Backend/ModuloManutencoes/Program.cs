using Microsoft.EntityFrameworkCore;
using ModuloManutencoes.Contexts;
using ModuloManutencoes.Dtos.DispositivoDtos;
using ModuloManutencoes.Dtos.MemoriaDtos;
using ModuloManutencoes.Dtos.UsuarioDtos;
using ModuloManutencoes.Interfaces;
using ModuloManutencoes.Interfaces.Usuarios;
using ModuloManutencoes.Middlewares;
using ModuloManutencoes.Repositories;
using ModuloManutencoes.Repositories.Interfaces;
using ModuloManutencoes.Services;
using ModuloManutencoes.Services.Interfaces;
using Microsoft.OpenApi.Models;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using System;
using System.Reflection;

namespace ModuloManutencoes
{
    public class Program
    {
        public static async Task Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen(c =>
            {
                //Configurando o swagger para ler o XML gerado dos comentários
                var xmlFile = $"{Assembly.GetExecutingAssembly().GetName().Name}.xml";
                var xmlPath = Path.Combine(AppContext.BaseDirectory, xmlFile);
                c.IncludeXmlComments(xmlPath);

                c.AddSecurityDefinition("Bearer", new OpenApiSecurityScheme
                {
                    Description = "JWT Authorization Header - utilizado com Bearer Authentication.\r\n\r\n" +
                    $"Digite {"Bearer"} e em seguida o token no campo abaixo.\r\n\r\n" +
                    $"Exemplo: {"Bearer 12345abcdef"}",
                    Name = "Authorization",
                    In = ParameterLocation.Header,
                    Type = SecuritySchemeType.ApiKey,
                    Scheme = "Bearer",
                    BearerFormat = "JWT"
                });

                c.AddSecurityRequirement(new OpenApiSecurityRequirement
                {
                    {
                        new OpenApiSecurityScheme {
                            Reference = new OpenApiReference {
                                Type = ReferenceType.SecurityScheme,
                                Id = "Bearer"
                            }
                        },
                        Array.Empty<string>()
                    }
                });
            });

            string jwtIssuer = builder.Configuration.GetSection("JwtConfiguration")["Issuer"];
            string jwtKey = builder.Configuration.GetSection("JwtConfiguration")["SecretJwtKey"];

            builder.Services.AddAuthentication(options =>
            {
                options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
                options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
            })
                .AddJwtBearer(options =>
            {
                options.TokenValidationParameters = new TokenValidationParameters
                {
                    ValidateIssuer = true,
                    ValidateAudience = true,
                    ValidateLifetime = true,
                    ValidateIssuerSigningKey = true,
                    ValidIssuer = jwtIssuer,
                    ValidAudience = jwtIssuer,
                    IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey)),
                };

                options.Events = new JwtBearerEvents
                {
                    OnChallenge = context =>
                    {
                        if (context.AuthenticateFailure?.GetType() == typeof(SecurityTokenExpiredException))
                        {
                            context.Response.StatusCode = 498;
                            context.Response.ContentType = "application/json";
                            return context.Response.WriteAsync("{\"error\":\"Token expired\"}");
                        }

                        context.Response.StatusCode = 401;
                        context.Response.ContentType = "application/json";
                        return context.Response.WriteAsync("{\"error\":\"Unauthorized\"}");
                    }
                };
            });

            string conexaoDb = builder.Configuration.GetSection("ConnectionStrings")["ConnectionDb"];

            //Adicionando os contextos dos bancos de dados
            builder.Services.AddDbContext<MODMANUTENCOESContext>(options => options.UseSqlServer(conexaoDb));

            //Repository da autenticação
            builder.Services.AddScoped<IAutenticacaoRepository, AutenticacaoRepository>();

            //Repository do usuário
            builder.Services.AddScoped<ICrud<int, UsuarioDTO, UsuarioGetDTO>, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();
            builder.Services.AddScoped<IValidadorUsuarioService, ValidadorUsuarioService>();

            //Repository do tipo de dispositivo
            builder.Services.AddScoped<ICrud<int, TipoDispositivoDTO, TipoDispositivoGetDTO>, TipoDispositivoRepository>();
            builder.Services.AddScoped<ITipoDispositivoRepository, TipoDispositivoRepository>();

            //Repository do tipo de memória ram
            builder.Services.AddScoped<ICrud<int, TipoMemoriaRamDTO, TipoMemoriaRamGetDTO>, TipoMemoriaRamRepository>();
            builder.Services.AddScoped<ITipoMemoriaRamRepository, TipoMemoriaRamRepository>();

            //Repository do tipo de memória vram
            builder.Services.AddScoped<ICrud<int, TipoMemoriaVramDTO, TipoMemoriaVramGetDTO>, TipoMemoriaVramRepository>();
            builder.Services.AddScoped<ITipoMemoriaVramRepository, TipoMemoriaVramRepository>();

            //Repository do dispositivo
            builder.Services.AddScoped<ICrud<int, DispositivoDTO, DispositivoGetDTO>, DispositivoRepository>();
            builder.Services.AddScoped<IDispositivoRepository, DispositivoRepository>();

            //Service da criptografia da senha
            builder.Services.AddScoped<IPasswordHasher, PasswordHasherService>();

            //Service do usuário
            builder.Services.AddScoped<IUsuarioService, UsuarioService>();

            //Service do tipo de dispositivo
            builder.Services.AddScoped<ITipoDispositivoService, TipoDispositivoService>();

            //Service do tipo de memória ram
            builder.Services.AddScoped<ITipoMemoriaRamService, TipoMemoriaRamService>();

            //Service do tipo de memória vram
            builder.Services.AddScoped<ITipoMemoriaVramService, TipoMemoriaVramService>();

            //Service do dispositivo
            builder.Services.AddScoped<IDispositivoService, DispositivoService>();
            builder.Services.AddScoped<IValidadorDispositivoService, ValidadorDispositivoService>();

            //Service da autenticação
            builder.Services.AddScoped<IAutenticacaoService, AutenticacaoService>();

            builder.Services.AddHttpContextAccessor();


            //Configurações da aplicação
            var app = builder.Build();

            string ambiente = app.Configuration.GetSection("Environment")["Dev"];

            app.UseStaticFiles();

            // Configure the HTTP request pipeline.
            if (ambiente == "Y")
            {
                app.UseSwagger();
                app.UseSwaggerUI(c =>
                {
                    c.SwaggerEndpoint("/swagger/v1/swagger.json", "ApiModuloManutencoes");
                    c.InjectStylesheet("/swagger-ui/SwaggerDark.css");
                });
            }

            app.UseHttpsRedirection();

            app.UseMiddleware<TratamentoExcecoesMiddleware>();

            app.UseAuthorization();
            app.UseAuthentication();

            //Configurando o CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
            });

            app.MapControllers();

            //Criando um usuário Super Administrador caso NÃO exista
            using (var scope = app.Services.CreateScope())
            {
                var services = scope.ServiceProvider;

                // Resolve o serviço e chama o método
                var userService = services.GetRequiredService<IUsuarioService>();
                await userService.CadastrarUsuarioSuperAdministradorCasoNaoExista();
            }

            app.Run();
        }
    }
}
