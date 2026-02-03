using playerregproject.Data;
using playerregproject.DTOs.CustomFieldDTOs;
using playerregproject.Interface.Repositories;
using playerregproject.Models;

namespace playerregproject.Interface.Services
{
    public class CustomFieldService : ICustomFieldService
    {
        private readonly PlayerRegDbContext _playerRegDbContext;

        public CustomFieldService(PlayerRegDbContext playerRegDbContext)
        {
            _playerRegDbContext = playerRegDbContext;
        }

        public async Task AddCustomFieldAsync(CreateCustomFieldDTO dto)
        {
            var customField = new CustomField
            {
                FormId = dto.FormId,
                FieldName = dto.FieldName,
                FieldType = dto.FieldType,
                IsRequired = dto.IsRequired,
                Values = new List<CustomFieldValue>() // Initialize the required 'Values' property
            };

            await _playerRegDbContext.CustomFields.AddAsync(customField);
            await _playerRegDbContext.SaveChangesAsync();

            //if (dto.FieldType == "dropdown" && dto.Values != null)
            //{
            //    var fieldValues = dto.Values.Select(v => new CustomFieldValue
            //    {
            //        CustomFieldId = customField.Id,
            //        FieldValue = new List<string> { v } // Wrap the string 'v' in a List<string>
            //    });

            //    customField.Values = fieldValues.ToList(); // Assign the generated values to the 'Values' property
            //}

            if(dto.FieldType == "dropdown" && dto.Values != null)
            {
                foreach(var val in dto.Values)
                {
                    _playerRegDbContext.CustomFieldValues.Add(new CustomFieldValue
                    {
                        CustomFieldId = customField.Id,
                        FieldValue = val
                    });
                }
            }

            await _playerRegDbContext.SaveChangesAsync();
        }
    }
    
}
