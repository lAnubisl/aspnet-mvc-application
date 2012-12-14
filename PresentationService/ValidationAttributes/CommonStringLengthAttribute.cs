using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonStringLengthAttribute : StringLengthAttribute
    {
        public CommonStringLengthAttribute(int maximumLength) : base(maximumLength)
        {
            ErrorMessage = Resources.ValidationMessages.X_CanNotBeLongerThan_Y_Characters;
        }
    }
}