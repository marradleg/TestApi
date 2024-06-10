using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MWCodeReview.Interfaces;

namespace MWCodeReview.Controllers
{
    public class UserController : ControllerBase
    {
        private readonly IUser service;

        public UserController(IUser user)
        {
            service = user;
        }

        [HttpPost("delete/{id}")]
       
        public async Task<IActionResult> DeleteUser(uint id)
        {
            var result = await service.DeleteUser(id);
            if(!result)
            return NotFound();

            return Ok(result);
                
        }
    }
}
