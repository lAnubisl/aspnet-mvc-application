using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class HttpsLinkAttribute : ValidationAttribute
    {
        public HttpsLinkAttribute()
        {
            ErrorMessage = "Url should start with https://";
        }

        public override bool IsValid(object value)
        {
            return value == null || value.ToString().StartsWith("https://", StringComparison.OrdinalIgnoreCase);
        }
    }
}