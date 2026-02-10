using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using playerregproject.DTOs.CustomFieldDTOs;
using playerregproject.Interface.Services;
using playerregproject.Models;
using System.Security.Claims;

namespace playerregproject.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class CustomFieldController : ControllerBase
    {
        private readonly ICustomFieldService _customFieldService;

        public CustomFieldController(ICustomFieldService customFieldService)
        {
            _customFieldService = customFieldService;
        }

        [HttpPost("CreateCustomField")]
         public async Task<IActionResult> CreateCustomField([FromBody] CreateCustomFieldDTO dto)
        {

            if (!ModelState.IsValid)
            {
                return BadRequest(ModelState); // 🔥 shows exact issue
            }
            await _customFieldService.AddCustomFieldAsync(dto);

            return Ok(new { message = "Custom Field added successfully" });



        }
    }
}
