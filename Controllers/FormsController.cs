using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using playerregproject.Interface.Services;
using playerregproject.Models;
using System.Security.Claims;

namespace playerregproject.Controllers
{
    [Authorize]
    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }



        [HttpPost]
        public async Task<IActionResult> CreateForm(Form form)

        {
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if(username == null)
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }


            await _formService.CreateTaskAsync(form, username);
            return Ok(new { message = "Form created successfully" });
        }





    }
}