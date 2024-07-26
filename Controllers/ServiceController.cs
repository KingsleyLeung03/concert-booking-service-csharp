using concert_booking_service_csharp.Data;
using concert_booking_service_csharp.Dtos;
using concert_booking_service_csharp.Models;
using concert_booking_service_csharp.Utils;
using Microsoft.AspNetCore.Authorization;
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

        [HttpPost("Register")]
        public ActionResult<string> Register(UserDTO input)
        {
            if (_repository.GetUserByUserName(input.UserName) == null)
            {
                //User user = _repository.AddUserHashed(input.userName, input.password);
                PasswordHasherUtil.CreatePasswordHash(input.Password, out byte[] passwordHash, out byte[] passwordSalt);
                User user = new User { UserName = input.UserName, PasswordHash = passwordHash, PasswordSalt = passwordSalt, Version = 1 };
                User addedUser = _repository.AddUser(user);
                return Ok("User successfully registered.");
            }
            else
            {
                return BadRequest("UserName " + input.UserName + " is not available.");
            }
        }

        [Authorize(AuthenticationSchemes = "Authentication")]
        [Authorize(Policy = "UserOnly")]
        [HttpPost("TestAuth")]
        public ActionResult<string> Login()
        {
            return Ok("Login successful");
        }

        [HttpGet("Performers")]
        public ActionResult GetAllPerformers()
        {
            IEnumerable<Performer> performers = _repository.GetAllPerformers();
            List<PerformerDTO> performerDTOs = new List<PerformerDTO>();
            foreach (Performer performer in performers)
            {
                performerDTOs.Add(new PerformerDTO { PerformerId = performer.PerformerId, Name = performer.Name, ImageName = performer.ImageName, Genre = performer.Genre, Blurb = performer.Blurb });
            }
            return Ok(performerDTOs);
        }


        //[HttpGet("Performers/{id}")]


    }
}
