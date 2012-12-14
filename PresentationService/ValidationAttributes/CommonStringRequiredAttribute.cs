using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonStringRequiredAttribute : RequiredAttribute
    {
        public CommonStringRequiredAttribute()
        {
            ErrorMessage = Resources.ValidationMessages.PleaseEnterValid_X;
        }
    }
}