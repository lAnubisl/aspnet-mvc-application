using System;
using System.ComponentModel.DataAnnotations;
using System.Net;

namespace PresentationService.ValidationAttributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public sealed class CheckLinkAttribute : ValidationAttribute
    {
        public CheckLinkAttribute()
        {
            ErrorMessage = "Url is not working";
        }

        public override bool IsValid(object value)
        {
            if (value == null)
            {
                return true;
            }

            string url = value.ToString();
            try
            {
                var request = (HttpWebRequest)WebRequest.Create(new Uri(url.Contains("://") ? url : "http://" + url));
                var response = (HttpWebResponse)request.GetResponse();
                return
                    response.StatusCode == HttpStatusCode.OK ||
                    response.StatusCode == HttpStatusCode.MovedPermanently ||
                    response.StatusCode == HttpStatusCode.Moved;
            }
            catch (WebException)
            {
                return false;
            }
        }
    }
}