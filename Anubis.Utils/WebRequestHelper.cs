using System;
using System.Collections.Specialized;
using System.IO;
using System.Net;
using System.Text;
using System.Text.RegularExpressions;

namespace Anubis.Utils
{
    public static class WebRequestHelper
    {
        public static byte[] DownloadData(Uri url)
        {
            string foo;
            return DownloadData(url, null, null, false, out foo);
        }

        public static byte[] DownloadData(Uri url, NameValueCollection postData, string requestCookies, bool allowRedirects, out string responseCookies)
        {
            return ReadFully(MakeRequest(url, postData, requestCookies, allowRedirects, out responseCookies).GetResponseStream());
        }

        public static string DownloadCookies(Uri url, NameValueCollection postData)
        {
            string responseCookies;
            DownloadString(url, postData, out responseCookies);
            return responseCookies;
        }

        public static string DownloadString(Uri url)
        {
            string responseCookies;
            return DownloadString(url, null, null, false, out responseCookies);
        }

        public static string DownloadString(Uri url, string requestCookies, bool allowRedirects)
        {
            string foo;
            return DownloadString(url, null, requestCookies, allowRedirects, out foo);
        }

        public static string DownloadString(Uri url, NameValueCollection postData, out string responseCookies)
        {
            return DownloadString(url, postData, null, false, out responseCookies);
        }

        public static string DownloadString(Uri url, NameValueCollection postData, string requestCookies, bool allowRedirects, out string responseCookies)
        {
            return
                Encoding.GetEncoding(1251).GetString(
                    DownloadData(url, postData, requestCookies, allowRedirects, out responseCookies));
        }

        private static byte[] ReadFully(Stream input)
        {
            var buffer = new byte[16384];
            using (var memoryStream = new MemoryStream())
            {
                int count;
                while ((count = input.Read(buffer, 0, buffer.Length)) > 0)
                    memoryStream.Write(buffer, 0, count);
                return memoryStream.ToArray();
            }
        }

        private static WebResponse MakeRequest(Uri url, NameValueCollection postData,
                                               string requestCookies, bool allowRedirects, out string responseCookies)
        {
            var httpWebRequest = (HttpWebRequest) WebRequest.Create(url);
            httpWebRequest.AllowAutoRedirect = allowRedirects;
            if (!string.IsNullOrEmpty(requestCookies))
            {
                httpWebRequest.Headers.Add(HttpRequestHeader.Cookie, requestCookies);
            }
            if (postData != null)
            {
                var stringBuilder = new StringBuilder();
                for (int index = 0; index < postData.Count; ++index)
                {
                    stringBuilder.Append(string.Format("{0}={1}", postData.AllKeys[index], postData[index]));
                    if (index + 1 < postData.Count)
                    {
                        stringBuilder.Append('&');
                    }
                }
                byte[] bytes = Encoding.UTF8.GetBytes((stringBuilder).ToString());
                httpWebRequest.Method = "POST";
                httpWebRequest.ContentType = "application/x-www-form-urlencoded";
                httpWebRequest.ContentLength = bytes.Length;
                Stream requestStream = (httpWebRequest).GetRequestStream();
                requestStream.Write(bytes, 0, bytes.Length);
                requestStream.Close();
            }
            else
            {
                httpWebRequest.Method = "GET";
            }
            WebResponse response = httpWebRequest.GetResponse();
            responseCookies = RemoveSetCookiesAttributes(response.Headers[HttpResponseHeader.SetCookie]);
            return response;
        }

        private static string RemoveSetCookiesAttributes(string setCookieString)
        {
            setCookieString = setCookieString + ",";
            setCookieString = Regex.Replace(setCookieString, "expires=[^;]*;", "");
            setCookieString = Regex.Replace(setCookieString, "path=[^;]*;", "");
            setCookieString = Regex.Replace(setCookieString, "domain=[^,]*,", "");
            return setCookieString;
        }
    }
}