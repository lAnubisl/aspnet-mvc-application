using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonStringLengthAttribute : StringLengthAttribute
    {
        public CommonStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessage = "{0} can not be longer than {1} characters.";
        }
    }
}