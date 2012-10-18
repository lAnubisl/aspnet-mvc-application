using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonStringRequiredAttribute : RequiredAttribute
    {
        public CommonStringRequiredAttribute()
        {
            ErrorMessage = "Please enter a valid {0}";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return false;
            }

            var temp = base.IsValid(value);
            return temp && !"<br/>".Equals(value.ToString().Trim()) && !"<br />".Equals(value.ToString().Trim()) && !"&nbsp;".Equals(value.ToString().Trim());
        }
    }
}