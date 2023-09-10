using FiapStore.DTO;
using FiapStore.Entity;
using FiapStore.Interface;
using Microsoft.AspNetCore.Mvc;

namespace FiapStore.Controllers
{

    [ApiController]
    [Route("User")]
    public class UserController : ControllerBase
    {
        private IUserRepository _userRepository;
        private ILogger<UserController> _logger;

        public UserController(IUserRepository userRepository, ILogger<UserController> logger)
        {
            _userRepository = userRepository;
            _logger = logger;
        }


        [HttpGet("obter-todos-com-pedido/{id}")]
        public IActionResult UserListWithOrder([FromRoute] int id)
        {
            return Ok(_userRepository.GetUserByOrdes(id));
        }

        [HttpGet("obter-usuario-por-id/{id}")]
        public IActionResult GetUser(int id)
        {
            _logger.LogInformation("Executando método GetUser.");
            return Ok(_userRepository.GetById(id));
        }


        [HttpGet("obter-todos-usuario")]
        public IActionResult UserList()
        {
            return Ok(_userRepository.ListAll());
        }

        [HttpPost]
        public IActionResult InsertUser(InsertUserDTO userDTO)
        {
            _userRepository.Insert(new User(userDTO));
            return Ok("Usuário criado com sucesso!");
        }

        [HttpPut]
        public IActionResult UpdateUser(UpdateUserDTO userDTO)
        {
            _userRepository.Update(new User(userDTO));
            return Ok("Usuário alterado com sucesso!");
        }

        [HttpDelete("{id}")]
        public IActionResult DeleteUser(int id)
        {
            _userRepository.Delete(id);
            return Ok("Usuário deletado com sucesso!");
        }
    }
}
