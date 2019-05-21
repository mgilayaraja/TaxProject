using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Web;
using System.Configuration;

namespace TaxProject.com.Utilities
{
    public class ApiClient : HttpClient
    {
        private string baseUrl;

        public ApiClient(string requestUrl, string methodType)
        {
            baseUrl = ConfigurationManager.AppSettings["ApiURL"];
            string completeUrl = baseUrl + requestUrl;

            //Passing service base url  
            BaseAddress = new Uri(baseUrl);
            DefaultRequestHeaders.Clear();
            DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
            DefaultRequestHeaders.TryAddWithoutValidation("Content-Type", "application/x-www-urlencoded");
        }

        public string PostAsAsync(string requestUrl, string requestBody)
        {
            string completeUrl = baseUrl + requestUrl;
            try
            {
                HttpWebRequest request = WebRequest.Create(completeUrl) as HttpWebRequest;
                request.ContentType = @"application/json";
                request.Method = @"POST";
                //request.Timeout=(4 * 60 * 1000);

                //request.Headers.Add(HttpRequestHeader.Authorization, formHeader(completeUrl, "POST"));

                StreamWriter requestWriter = new StreamWriter(request.GetRequestStream());
                requestWriter.Write(requestBody);
                requestWriter.Close();

                HttpWebResponse webResponse = (HttpWebResponse)request.GetResponse();

                StreamReader responseReader = new StreamReader(webResponse.GetResponseStream());
                return responseReader.ReadToEnd();

            }
            catch (WebException ex)
            {
                //reading the custom messages sent by the server
                using (var reader = new StreamReader(ex.Response.GetResponseStream()))
                {
                    return reader.ReadToEnd();
                }
            }
            catch (Exception ex)
            {
                return ex.Message + ex.InnerException + "--error" + "requestString:::::::::::: " + requestBody;
            }
        }

    }
}