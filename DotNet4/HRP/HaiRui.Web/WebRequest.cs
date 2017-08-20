using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;

namespace HaiRui.Web
{
    public static class WebRequest
    {
        /// <summary>
        /// Get请求
        /// </summary>
        /// <param name="url">Url</param>
        /// <returns>返回字符串</returns>
        public static string Get(string url)
        {
            HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;
            request.Proxy = null;
            var response = (HttpWebResponse)request.GetResponse();
            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;
        }
        /// <summary>
        /// Post请求
        /// </summary>
        /// <param name="url">Url</param>
        /// <param name="postData">提交数据</param>
        /// <returns>返回字符串</returns>
        public static string Post(string url, string postData)
        {
            HttpWebRequest request = System.Net.WebRequest.Create(url) as HttpWebRequest;

            byte[] data = Encoding.UTF8.GetBytes(postData);

            //byte[] data = Encoding.ASCII.GetBytes(postData);
            request.Method = "POST";
            request.KeepAlive = false;
            request.AllowAutoRedirect = true;
            request.ContentType = "application/x-www-form-urlencoded";
            request.ContentLength = data.Length;
            request.Proxy = null;
            using (var stream = request.GetRequestStream())
            {
                stream.Write(data, 0, data.Length);
            }

            var response = (HttpWebResponse)request.GetResponse();

            var responseString = new StreamReader(response.GetResponseStream()).ReadToEnd();
            return responseString;

        }
    }
}
