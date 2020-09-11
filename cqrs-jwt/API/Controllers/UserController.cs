using Application.Commands;
using Microsoft.AspNetCore.Mvc;
using System.Threading.Tasks;

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiController
    {
        [HttpPost("createuser")]
        public async Task<IActionResult>
          UpdateSocialDetails([FromBody] CreateUserCommand createUser)
        {
            var result = await Mediator.Send(createUser);
            return result != null ? Created("",  result) : (IActionResult)BadRequest(result);
        }
    }
}
