namespace Anexa.API.Middleware
{
    public class LoginRequisicaoMiddleware
    {
        private readonly RequestDelegate _next;

        public LoginRequisicaoMiddleware(RequestDelegate next)
        {
            _next = next;
        }

        public async Task Invoke(HttpContext context)
        {
            var rota = context.Request.Path;
            var metodo = context.Request.Method;
            var usuario = context.User.Identity?.Name ?? "Não autenticado";
            var horario = DateTime.UtcNow;

            Console.WriteLine($"[{horario}]  {metodo} {rota} por {usuario}");

            await _next(context);
        }
    }
}
