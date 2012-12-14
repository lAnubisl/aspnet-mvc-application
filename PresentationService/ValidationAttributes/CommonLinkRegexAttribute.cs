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
            ErrorMessage = Resources.ValidationMessages.PleaseEnterValid_X;
        }

        public CommonLinkRegexAttribute(string pattern) : base(pattern)
        {
            ErrorMessage = Resources.ValidationMessages.PleaseEnterValid_X;
        }
    }
}