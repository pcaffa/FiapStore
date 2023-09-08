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

            //construtor
            public UserController(IUserRepository userRepository)
            {
                _userRepository = userRepository; //injeção
            }

            [HttpGet("obter-usuario-por-id/{id}")]
            public IActionResult GetUser(int id)
            {
                return Ok(_userRepository.GetUser(id));
            }


            [HttpGet]
            public IActionResult ListUsers()
            {
                return Ok(_userRepository.ListUser());
            }

            [HttpPost]
            public IActionResult InsertUser(User user)
            {
                _userRepository.InsertUser(user);
                return Ok("Usuário criado com sucesso!");
            }

            [HttpPut]
            public IActionResult UpdateUser(User user)
            {
                _userRepository.UpdateUser(user);
                return Ok("Usuário alterado com sucesso!");
            }

            [HttpDelete("{id}")]
            public IActionResult DeleteUser(int id)
            {
                _userRepository.DeleteUser(id);
                return Ok("Usuário deletado com sucesso!");
            }
    }
}
