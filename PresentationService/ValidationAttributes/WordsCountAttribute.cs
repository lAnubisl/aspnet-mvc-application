using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class WordsCountAttribute : StringLengthAttribute
    {
        private readonly int wordsCount;
        private static readonly Regex TagPattern = new Regex(@"<.*?>");

        public WordsCountAttribute(int wordsCount)
            : base(wordsCount)
        {
            this.wordsCount = wordsCount;
            ErrorMessage = "Can not be longer than {1} words.";
        }

        public int WordsCount
        {
            get { return wordsCount; }
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            var st = RemoveTags(value.ToString()).Split(' ');
            return st.Length <= wordsCount;
        }

        private static string RemoveTags(string text)
        {
            if (!string.IsNullOrEmpty(text))
            {
                text = TagPattern.Replace(text, string.Empty);
                text = text.Replace("&nbsp;", " ");
                return text;
            }

            return string.Empty;
        }
    }
}