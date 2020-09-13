using Application.Commands;
using Application.Handlers.QHandlers;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpPost("createuser")]
        [Authorize]
        public async Task<IActionResult>
          CreateuserAsync([FromBody] CreateUserCommand createUser)
        {
            var result = await Mediator.Send(createUser);
            return result != null ? Created("", result) : (IActionResult)BadRequest(result);
        }

        [HttpPost("login")]
        public async Task<IActionResult>
         LoginAsync([FromBody] LoginCommand login)
        {
            var result = await Mediator.Send(login);
            return result != null ? Created("", result) : (IActionResult)BadRequest(result);
        }


        [HttpGet("getuser/{userid}")]
        [Authorize]
        public async Task<IActionResult>
         FindUserByIdAsync([FromRoute] string userid)
        {
            var result = await Mediator.Send(new UserInfoQuery { UserId = userid });
            return result != null ? Ok(result) : (IActionResult)NotFound();
        }
    }
}
