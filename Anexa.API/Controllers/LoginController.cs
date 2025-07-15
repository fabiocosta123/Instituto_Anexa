using Anexa.Application.DTOs;
using Anexa.Application.Services;
using Anexa.Domain.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace Anexa.API.Controllers
{
    [ApiController]
    [Route("api/[controller]")]
    public class LoginController : ControllerBase
    {
        private readonly IUsuarioRepository _usuarioRepository;
        private readonly JwtService _jwtService;

        public LoginController(IUsuarioRepository usuarioRepository, JwtService jwtService)
        {
            _usuarioRepository = usuarioRepository;
            _jwtService = jwtService;
        }

        [HttpPost]
        public async Task<IActionResult> Login([FromBody] LoginRequest request)
        {
            var usuario = await _usuarioRepository.ObterPorEmail(request.Email);

            if (usuario is null || !BCrypt.Net.BCrypt.Verify(request.Senha, usuario.SenhaHash))
                return Unauthorized("Email ou senha inválidos");

            var token = _jwtService.GerarToken(usuario);
            return Ok(new { access_token = token });
        }
    }
}
