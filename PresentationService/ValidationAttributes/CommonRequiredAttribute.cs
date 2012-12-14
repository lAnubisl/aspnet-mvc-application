using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonRequiredAttribute : RequiredAttribute
    {
        public CommonRequiredAttribute()
        {
            ErrorMessage = Resources.ValidationMessages.X_IsRequired;
        }
    }
}