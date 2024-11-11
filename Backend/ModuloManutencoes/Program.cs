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

namespace ModuloManutencoes
{
    public class Program
    {
        public static void Main(string[] args)
        {
            var builder = WebApplication.CreateBuilder(args);

            // Add services to the container.

            builder.Services.AddControllers();
            // Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
            builder.Services.AddEndpointsApiExplorer();
            builder.Services.AddSwaggerGen();

            string conexaoDb = builder.Configuration.GetSection("ConnectionStrings")["ConnectionDb"];

            //Adicionando os contextos dos bancos de dados
            builder.Services.AddDbContext<MODMANUTENCOESContext>(options => options.UseSqlServer(conexaoDb));

            //Repository do usuário
            builder.Services.AddScoped<ICrud<int, UsuarioDTO, UsuarioGetDTO>, UsuarioRepository>();
            builder.Services.AddScoped<IUsuarioRepository, UsuarioRepository>();

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

            //Configurando o CORS
            app.UseCors(c =>
            {
                c.AllowAnyHeader();
                c.AllowAnyOrigin();
            });


            app.MapControllers();

            app.Run();
        }
    }
}