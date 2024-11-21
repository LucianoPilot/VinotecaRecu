using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using VinotecaRecu.Data.Entities;
using VinotecaRecu.Data.Repositories;
using VinotecaRecu.Models;
using VinotecaRecu.Services.Interfaces;

namespace VinotecaRecu.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UserController : ControllerBase
    {
        private readonly IUserService _userService;
        public UserController(IUserService userService)
        {
            _userService = userService;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserDTO dto)
        {
            _userService.CreateUser(dto);
            return Ok(dto);

        }
    }
}
