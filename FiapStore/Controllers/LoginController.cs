using FiapStore.DTO;
using FiapStore.Interface;
using FiapStore.Services;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{
    [ApiController]
    [Route("login")]
    public class LoginController : ControllerBase
    {
        private readonly IUserRepository _userRepository;
        private readonly ITokenService _tokenService;

        public LoginController(IUserRepository userRepository, ITokenService tokenService)
        {
            _userRepository = userRepository;
            _tokenService = tokenService;
        }

        [HttpPost]
        public IActionResult Authenticate([FromBody] LoginDTO userDto)
        {
            var user = _userRepository.GetByUserNamePassword(userDto.UserName, userDto.Password);

            if (user == null)
                return NotFound(new { msg = "Usuário ou senha inválidos" });

            var token = _tokenService.GenerateToken(user);
            user.Passaword = "";

            return Ok(new
            {
                User = user,
                Toke = token

            });
        }
    }
}
