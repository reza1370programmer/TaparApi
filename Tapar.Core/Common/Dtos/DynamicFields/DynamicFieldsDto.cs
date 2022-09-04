namespace Tapar.Core.Common.Dtos.DynamicFields
{
    public class DynamicFieldsDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string enTitle { get; set; }
        public string? minLength { get; set; }
        public string? maxLength { get; set; }
        public int isRequired { get; set; }
        public int cat2Id { get; set; }
        public int fieldTypeId { get; set; }
    }
}
