using ModuloManutencoes.Exceptions.DispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoDispositivoExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaRamExceptions;
using ModuloManutencoes.Exceptions.TipoMemoriaVramExceptions;
using ModuloManutencoes.Exceptions.UsuariosExceptions;

namespace ModuloManutencoes.Middlewares
{
    public class TratamentoExcecoesMiddleware
    {
        private readonly RequestDelegate _next;
        private readonly ILogger<TratamentoExcecoesMiddleware> _logger;
        private readonly IConfiguration _configuration;

        public TratamentoExcecoesMiddleware(RequestDelegate next, ILogger<TratamentoExcecoesMiddleware> logger, IConfiguration configuration)
        {
            _next = next;
            _logger = logger;
            _configuration = configuration;
        }

        public async Task InvokeAsync(HttpContext context)
        {

            string ambiente = _configuration.GetSection("Environment")["Dev"];

            try
            {
                await _next(context);
            }
            catch (UsuarioNaoEncontradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "404. Isto é um erro.")}");
            }
            catch (EmailJaCadastradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "400. Isto é um erro.")}");
            }
            catch (UsuarioApagadoException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "400. Isto é um erro.")}");
            }
            catch (TipoDispositivoNaoEncontradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : $"404. Isto é um erro.")}");
            }
            catch (TipoMemoriaRamNaoEncontradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : $"404. Isto é um erro.")}");
            }
            catch (DescricaoTipoMemoriaRamJaExisteException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "400. Isto é um erro.")}");
            }
            catch (TipoMemoriaVramNaoEncontradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : $"404. Isto é um erro.")}");
            }
            catch (DescricaoTipoMemoriaVramJaExisteException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "400. Isto é um erro.")}");
            }
            catch (DispositivoNaoEncontradoException e)
            {
                context.Response.StatusCode = StatusCodes.Status404NotFound;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : $"404. Isto é um erro.")}");
            }
            catch (DispositivoJaExisteException e)
            {
                context.Response.StatusCode = StatusCodes.Status400BadRequest;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? e.Message : "400. Isto é um erro.")}");
            }
            catch (Exception e)
            {
                _logger.LogError(e, "500. Isto é um erro.");
                context.Response.StatusCode = StatusCodes.Status500InternalServerError;
                await context.Response.WriteAsync($"{(ambiente == "Y" ? "Mensagem: " + e.Message + "\nDetalhes internos: " + (e.InnerException?.Message ?? "") : "500. Isto é um erro.")}");
            }
        }
    }
}
