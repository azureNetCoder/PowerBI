using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;
using Microsoft.PowerBI.Api;
using Microsoft.PowerBI.Api.V2;
using Newtonsoft.Json;

namespace PowerBI.Worker.Processing
{
    public class PowerbiClient
    {
        private readonly string powerbiHost;

        public PowerbiClient(string baseUrl)
        {
            this.powerbiHost = baseUrl;
        }
        
        /// <summary>
        ///     This is a generic HTTP GET method which returns a deserialized object by parsing it into a specified Model type.
        /// </summary>
        /// <typeparam name="T">The type of the model expected from the API response.</typeparam>
        /// <param name="apiUrl">The API relative URL.</param>
        /// <param name="bearerToken">The bearer token of the API.</param>
        /// <returns></returns>
        public T HttpGetMethodCaller<T>(string apiUrl, string bearerToken)
        {
            string responseString = string.Empty;

            var httpRequest = (HttpWebRequest)WebRequest.Create(
                string.Concat(
                    this.powerbiHost,
                    apiUrl));

            httpRequest.Method = "GET";
            httpRequest.Headers.Add("Authorization", string.Format("Bearer {0}", bearerToken));

            try
            {
                var response = httpRequest.GetResponse() as HttpWebResponse;

                using (var reader = new StreamReader(response.GetResponseStream()))
                {
                    responseString = reader.ReadToEnd();
                }

                var structuredObject = JsonConvert.DeserializeObject<T>(responseString);

                return structuredObject;
            }
            catch(WebException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }

        /// <summary>
        ///     This is a generic HTTP GET method which returns a deserialized object by parsing it into a specified Model type.
        /// </summary>
        /// <typeparam name="T">The type of the model expected from the API response.</typeparam>
        /// <param name="apiUrl">The API relative URL.</param>
        /// <param name="content">The content to be passed in the body.</param>
        /// <param name="bearerToken">The bearer token of the API.</param>
        /// <returns></returns>
        public T HttpPostMethodCaller<T>(string apiUrl, string content, string bearerToken)
        {
            string responseString = string.Empty;
            var byteContent = Encoding.UTF8.GetBytes(content);

            var httpRequest = (HttpWebRequest)WebRequest.Create(
                string.Concat(
                    this.powerbiHost,
                    apiUrl));

            httpRequest.Method = "POST";
            httpRequest.Headers.Add("Authorization", string.Format("Bearer {0}", bearerToken));
            httpRequest.ContentType = "application/json";

            try
            {
                using (var writer = httpRequest.GetRequestStream())
                {
                    writer.Write(byteContent, 0, byteContent.Length);

                    var response = httpRequest.GetResponse() as HttpWebResponse;

                    using (var reader = new StreamReader(response.GetResponseStream()))
                    {
                        responseString = reader.ReadToEnd();
                    }
                }

                var structuredObject = JsonConvert.DeserializeObject<T>(responseString);

                return structuredObject;
            }
            catch (WebException ex)
            {
                throw new InvalidOperationException(ex.Message);
            }
        }
    }
}
