using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class PositiveNumberAttribute : RangeAttribute
    {
        public PositiveNumberAttribute() : base(1, int.MaxValue)
        {
            ErrorMessage = Resources.ValidationMessages.X_ShouldBeAPositiveNumber;
        }
    }
}