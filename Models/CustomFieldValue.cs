using System.ComponentModel.DataAnnotations;

namespace playerregproject.Models
{
    public class CustomFieldValue
    {
        [Key]
        public int Id { get; set; }
        
        public int CustomFieldId { get; set; }
        
        public string FieldValue { get; set; } = string.Empty;

        public CustomField CustomField { get; set; }
    }
}
