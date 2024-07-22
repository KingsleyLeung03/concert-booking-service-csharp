using concert_booking_service_csharp.Data;
using concert_booking_service_csharp.Dtos;
using concert_booking_service_csharp.Models;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;

namespace concert_booking_service_csharp.Controllers
{
    [Route("concert-service")]
    [ApiController]

    public class ServiceController : Controller
    {
        private readonly IServiceRepo _repository;
        
        public ServiceController(IServiceRepo repository)
        {
            _repository = repository;
        }

        [HttpPost("register")]
        public ActionResult<string> Register(UserDTO input)
        {
            if (_repository.GetUserByUserName(input.userName) == null)
            {
                User user = _repository.AddUserHashed(input.userName, input.password);
                return Ok("User successfully registered.");
            }
            else
            {
                return Ok("UserName " + input.userName + " is not available.");
            }
        }


    }
}
