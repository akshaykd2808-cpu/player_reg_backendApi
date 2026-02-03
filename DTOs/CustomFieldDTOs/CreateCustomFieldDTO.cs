namespace playerregproject.DTOs.CustomFieldDTOs
{
    public class CreateCustomFieldDTO
    {
        public int FormId { get; set; }
        public string FieldName { get; set; } = string.Empty;

        public string FieldType { get; set; } = string.Empty;

        public int IsRequired { get; set; }

        public List<string> Values { get; set; }

    }
}
