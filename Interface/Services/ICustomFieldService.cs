using playerregproject.DTOs.CustomFieldDTOs;
using playerregproject.Models;

namespace playerregproject.Interface.Services
{
    public interface ICustomFieldService
    {
        Task AddCustomFieldAsync(CreateCustomFieldDTO dto);


    }
}
