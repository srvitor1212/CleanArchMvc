using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

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
                return GenerateToken(userInfo);
            } else
            {
                ModelState.AddModelError(
                    string.Empty,
                    "Credenciais inválidas");
                return BadRequest();
            }
        }

        [HttpPost("CreateUser")]
        [ApiExplorerSettings(IgnoreApi = true)]
        public async Task<ActionResult> CreateUser([FromBody] LoginModel userInfo)
        {
            var result = await _authenticate.RegisterUser(userInfo.Email, userInfo.Password);

            if (result)
            {
                return Ok($"User {userInfo.Email} was created successfully");
            }
            else
            {
                ModelState.AddModelError(string.Empty, "Invalid Login attempt.");
                return BadRequest(ModelState);
            }
        }

        private UserToken GenerateToken(LoginModel userInfo)
        {
            //PAYLOAD
            var claims = new[]
            {
                new Claim("email", userInfo.Email),
                new Claim("empresa", "Minha Empresa LTDA"),
                new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString())
            };

            //CHAVE SECRETA
            var chaveSecreta = _configuration["Jwt:SecretKey"];
            var encodeUTF8 = Encoding.UTF8.GetBytes(chaveSecreta);
            var chaveSimetrica = new SymmetricSecurityKey(encodeUTF8);

            //ASSINATURA
            var credenciais = new SigningCredentials(chaveSimetrica, SecurityAlgorithms.HmacSha256);

            //TEMPO EXPIRAÇÃO
            var dataExpiracao = DateTime.UtcNow.AddMinutes(15);

            //GERA O TOKEN COMPLETO
            JwtSecurityToken token = new JwtSecurityToken(
                issuer: _configuration["Jwt:Issuer"],
                audience: _configuration["Jwt:Audience"],
                claims: claims,
                signingCredentials: credenciais
                );

            var tokenJWT = new UserToken()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                Expiration = dataExpiracao
            };
            return tokenJWT;
        }
    }
}

