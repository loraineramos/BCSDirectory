using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace EmployeeDirectory.Web.Common
{
    public class ServiceRepository
    {
        public HttpClient Client { get; set; }
        public ServiceRepository()
        {
            Client = new HttpClient();
            Client.BaseAddress = new Uri("http://localhost:5240");//http://localhost:5240/api/user
        }
        public HttpResponseMessage GetResponse(string url)
        {
            var response = Client.GetAsync(url).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error in sending the request");
            return response;
        }
        public HttpResponseMessage PutResponse(string url, object model)
        {
            return Client.PutAsync(url, CreateHttpContent<object>(model)).Result;
        }
        public HttpResponseMessage PostResponse(string url, object model)
        {
            var response = Client.PostAsync(url, CreateHttpContent<object>(model)).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error in sending the request");
            return response;
        }
        public HttpResponseMessage DeleteResponse(string url)
        {
            var response = Client.DeleteAsync(url).Result;
            if (!response.IsSuccessStatusCode)
                throw new Exception("Error in sending the request");
            return response;
        }
        private HttpContent CreateHttpContent<T>(T content)
        {
            var json = JsonConvert.SerializeObject(content, MicrosoftDateFormatSettings);
            return new StringContent(json, Encoding.UTF8, "application/json");
        }
        private static JsonSerializerSettings MicrosoftDateFormatSettings
        {
            get
            {
                return new JsonSerializerSettings
                {
                    DateFormatHandling = DateFormatHandling.MicrosoftDateFormat
                };
            }
        }

    }
}
