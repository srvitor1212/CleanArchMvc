using CleanArchMvc.API.Models;
using CleanArchMvc.Domain.Account;
using Microsoft.AspNetCore.Mvc;

namespace CleanArchMvc.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class TokenController : ControllerBase
    {
        private readonly IAuthenticate _authenticate;

        public TokenController(IAuthenticate authenticate)
        {
            _authenticate = authenticate ?? 
                throw new ArgumentNullException(nameof(authenticate));
        }

        [HttpPost("LoginUser")]
        public async Task<ActionResult<UserToken>> Login([FromBody] LoginModel model)
        {
            throw new NotImplementedException();
        }
    }
}
