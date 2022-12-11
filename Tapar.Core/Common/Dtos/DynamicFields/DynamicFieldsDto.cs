﻿namespace Tapar.Core.Common.Dtos.DynamicFields
{
    public class DynamicFieldsDto
    {
        public int id { get; set; }
        public string title { get; set; }
        public string enTitle { get; set; }
        public string? maxLength { get; set; }
        public bool isRequired { get; set; }
    }
}
