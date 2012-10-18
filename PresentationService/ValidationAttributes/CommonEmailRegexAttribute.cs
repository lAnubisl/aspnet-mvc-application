using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonEmailRegexAttribute : RegularExpressionAttribute
    {
        public CommonEmailRegexAttribute() : base(@"^[\w-\.]+@([\w-]+\.)+[\w-]{2,4}$")
        {
            ErrorMessage = "Please enter valid {0}.";
        }
    }
}