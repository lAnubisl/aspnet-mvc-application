using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonRequiredAttribute : RequiredAttribute
    {
        public CommonRequiredAttribute()
        {
            ErrorMessage = "{0} is Required.";
        }
    }
}