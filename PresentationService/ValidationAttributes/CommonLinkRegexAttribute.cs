using System;
using System.ComponentModel.DataAnnotations;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CommonLinkRegexAttribute : RegularExpressionAttribute
    {
        public CommonLinkRegexAttribute()
            : base(@"(\w+:{0,1}\w*@)?([\S ]+)(:[0-9]+)?(\/|\/([\w#!:.?+=&%@!\-\/]))?")
        {
            ErrorMessage = "Please enter a valid {0}";
        }

        public CommonLinkRegexAttribute(string pattern) : base(pattern)
        {
            ErrorMessage = "Please enter a valid {0}";
        }
    }
}