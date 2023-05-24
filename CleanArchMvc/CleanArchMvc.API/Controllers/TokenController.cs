using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;
        private readonly IConfiguration _configuration;

        public TokenController(IAuthenticate authenticate, IConfiguration configuration)
        {
            _authenticate = authenticate ??
                throw new ArgumentNullException(nameof(authenticate));

            _configuration = configuration ?? 
                throw new ArgumentNullException();
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.Authenticate(userInfo.Email, userInfo.Password);
            if (result)
            {
                //todo: return GenerateToken(userInfo);
                return Ok($"Usuário {userInfo.Email} logou com sucesso!");
            } else
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Credenciais inválidas");
                return BadRequest();
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("empresa", "Minha Empresa LTDA"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //todo: parei aqui
            //var chaveSecreta = new SymmetricSecurityKey()
        }
    }
}
