using System;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Text;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raw5MovieDb_WebApi.Model;
using Xunit;
namespace Raw5MovieDb_WebApi.Tests
{
    public class TitleTests
    {
        private const string TitlesApi = "https://localhost:5001/api/titles";

        [Fact]
        public void Title_Object_HasTconstAndPrimarytitle()
        {
            var title = new Title();
            Assert.Null(title.Primarytitle);
            Assert.Null(title.Tconst);
        }

        [Fact]
        public void ApiTitles_GetWithNoArguments_OkAndAllTitles()
        {
            var (data, statusCode) = GetArray(TitlesApi);
            Console.WriteLine(data.Count);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(55076, data.Count);
            Assert.Equal("Çocuk", data.First()["primarytitle"]);
            Assert.Equal("Catherine: Full Body", data.Last()["primarytitle"]);
        }



        // Helpers
        // Borrowed from Henrik Bulskov

        (JArray, HttpStatusCode) GetArray(string url)
        {
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JArray)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) GetObject(string url)
        {
            var client = new HttpClient();
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();
            var requestContent = new StringContent(
                JsonConvert.SerializeObject(content),
                Encoding.UTF8,
                "application/json");
            var response = client.PostAsync(url, requestContent).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        HttpStatusCode PutData(string url, object content)
        {
            var client = new HttpClient();
            var response = client.PutAsync(
                url,
                new StringContent(
                    JsonConvert.SerializeObject(content),
                    Encoding.UTF8,
                    "application/json")).Result;
            return response.StatusCode;
        }

        HttpStatusCode DeleteData(string url)
        {
            var client = new HttpClient();
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }
    }
}