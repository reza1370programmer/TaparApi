namespace TaparApi.Common.Dtos.DynamicFields;

public class DynamicFieldSelectDto
{
    public string title { get; set; }
    public string enTitle { get; set; }
    public string? minLength { get; set; }
    public string? maxLength { get; set; }
    public string? regex { get; set; }
    public long? businessType1Id { get; set; }
    public long? businessType2Id { get; set; }
    public int fieldTypeId { get; set; }
}