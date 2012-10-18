using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using Foolproof;

namespace PresentationService.ValidationAttributes
{
    internal sealed class ProductCountCorrectAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var productCount = value is long ? (long)value : default(long);
            if (productCount > 0)
            {
                return true;
            }

            ErrorMessage = "Количество должно быть положительным";
            return false;
        }
    }
}
