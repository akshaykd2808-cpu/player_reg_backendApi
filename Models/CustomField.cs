using Microsoft.EntityFrameworkCore.Metadata.Internal;
using System.ComponentModel.DataAnnotations;

namespace playerregproject.Models
{
    public class CustomField
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public int FormId { get; set; }

        [Required]
        public string FieldName { get; set; }   = string.Empty;
        [Required]
        public string FieldType { get; set; } = string.Empty;

        [Required]
        public bool IsRequired { get; set; }

        public ICollection<CustomFieldValue>? Values { get; set; } 

    }
}

