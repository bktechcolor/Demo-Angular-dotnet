using DemoBusiness.Data.Services;
using DemoBusiness.Data.ViewModels;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace DemoProject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UsersController : ControllerBase
    {
        private readonly IUserBusiness _userBusiness;
        public UsersController(IUserBusiness userBusiness)
        {
            this._userBusiness = userBusiness;
        }
        [HttpGet]
        [Route("get-all-users")]
        public async Task<IActionResult> GetListUser()
        {
            await _userBusiness.ListUsersAsync();
            return (StatusCode(StatusCodes.Status200OK, new { Message = "Get List successfull !" }));
        }
        [HttpGet("get-user/{id:int?}")]
        public async Task<IActionResult> GetUser(int id)
        {
            await _userBusiness.GetUserByIdAsync(id);
            return (StatusCode(StatusCodes.Status200OK, new { Message = "Get successfull !" }));
        }
        [HttpPost("edit-user/{id:int?")]
        public async Task<IActionResult> EditUserAsync(int id, [FromBody] UserVM user)
        {
            var editUser = await _userBusiness.SaveUserAsync(id, user);
            return (StatusCode(StatusCodes.Status200OK,new {Message = "Edit successfull !"}));
        }
        [HttpDelete("delete-user/{id:int?")]
        public async Task<IActionResult> DeleteUserAsync(int id)
        {
            await _userBusiness.DeleteUserAsync(id);
            return (StatusCode(StatusCodes.Status200OK, new { Message = "Delete successfull !" }));
        }
    }
}
