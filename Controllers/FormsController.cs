using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using playerregproject.Interface.Services;
using playerregproject.Models;
using System.Security.Claims;

namespace playerregproject.Controllers
{

    [Route("api/[controller]")]
    [ApiController]
    public class FormsController : ControllerBase
    {

        private readonly IFormService _formService;

        public FormsController(IFormService formService)
        {
            _formService = formService;
        }



        [HttpPost("CreateForm")]
        public async Task<IActionResult> CreateForm([FromForm] Form form)

        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState);

            }
            var username = User.FindFirst(ClaimTypes.NameIdentifier)?.Value;

            if (username == null)
            {
                return Unauthorized(new { message = "User is not authenticated" });
            }


            await _formService.CreateTaskAsync(form, username);
            return Ok(new { message = "Form created successfully" });
        }

        [HttpGet("GetForms")]
        public async Task<IActionResult> GetFormsForDropdown()
        {
            var forms = await _formService.GetFormsAsync(); // Correctly call the method to retrieve the list of forms

            var activeForms = forms
                .Where(x => x.isActive) // Use the correct property name 'isActive' (case-sensitive)
                .Select(x => new Form
                {
                    Id = x.Id,
                    FormName = x.FormName
                })
                .ToList();

            return Ok(activeForms);
        }
    }

}