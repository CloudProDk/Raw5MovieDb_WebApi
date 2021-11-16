using System;
using System.Diagnostics;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.Http.Headers;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using Raw5MovieDb_WebApi.Model;
using Raw5MovieDb_WebApi.ViewModels;
using Xunit;
namespace Raw5MovieDb_WebApi.Tests
{
    public class TitleTests
    {
        private const string TitlesApi = "https://localhost:5001/api/titles";
        private const string AuthenticationApi = "https://localhost:5001/api/Authentication";
        private const string BookmarkApi = "https://localhost:5001/api/TitleBookmark";
        private const string RatingApi = "https://localhost:5001/api/Rating";
        private const string SearchHistoryApi = "https://localhost:5001/api/SearchHistory";
        private const string UserApi = "https://localhost:5001/api/User";
        private string bearerToken = "eyJhbGciOiJIUzI1NiIsInR5cCI6IkpXVCJ9.eyJ1bmlxdWVfbmFtZSI6IjkiLCJyb2xlIjoiQWRtaW4iLCJodHRwOi8vc2NoZW1hcy5taWNyb3NvZnQuY29tL3dzLzIwMDgvMDYvaWRlbnRpdHkvY2xhaW1zL3ZlcnNpb24iOiJWMy4xIiwibmJmIjoxNjM3MDY2NjUzLCJleHAiOjE2MzcyMzk0NTMsImlhdCI6MTYzNzA2NjY1M30.e0cgE7Cx2nkAcQw5PyHJk0PvU6KNxCJU1XLtw8MOjZg";

        [Fact]
        public void Title_Object_HasTconstAndPrimarytitle()
        {
            var title = new Title();
            Assert.Null(title.Primarytitle);
            Assert.Null(title.Tconst);
        }

        // [Fact]
        // public void ApiTitles_GetWithNoArguments_OkAndAllTitles()
        // {
        //     var (data, statusCode) = GetArray(TitlesApi);
        //     Console.WriteLine(data.Count);
        //     Assert.Equal(HttpStatusCode.OK, statusCode);
        //     Assert.Equal(55076, data.Count);
        //     Assert.Equal("Çocuk", data.First()["primarytitle"]);
        //     Assert.Equal("Catherine: Full Body", data.Last()["primarytitle"]);
        // }


        /* --------------------------- Authentication --------------------------- */

        [Fact]
        public void AuthenticateWithUnknownUser()
        {
            var user = new { username = "Legende", password = "legend" };

            var (result, statusCode) = PostData($"{AuthenticationApi}?username={user.username}&password={user.password}", user);
            Debug.WriteLine("result");
            Debug.WriteLine(result);
            Debug.WriteLine(statusCode);
            Assert.Equal(HttpStatusCode.BadRequest, statusCode);

        }

        [Fact]
        public void AuthenticateWithUser()
        {
            var user = new { username = "Legenden", password = "legend" };
            var (result, statusCode) = PostData($"{AuthenticationApi}?username={user.username}&password={user.password}", user);
            UserAccountViewModel newUser = JsonConvert.DeserializeObject<UserAccountViewModel>(JsonConvert.SerializeObject(result));

            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotNull(newUser.Token);
        }

        /* --------------------------- User --------------------------- */

        [Fact]
        public void RegisterNewUser()
        {

            var user = new UserAccount { Uconst = "1", UserName = "UnitTestUser", Email = "UnitTest@Email.com", Birthdate = new DateTime(1986 - 10 - 10), Password = "CantBeHacked" };
            var (result, statusCode) = PostData($"{UserApi}/Register?Uconst={user.Uconst}&UserName={user.UserName}&Email={user.Email}&Birthdate=1986-10-10&Password={user.Password}", user);
            UserAccount returnedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));

            Assert.Equal(HttpStatusCode.Created, statusCode);

            DeleteData($"{UserApi}/{returnedUser.Uconst}");
        }
        [Fact]
        public void UpdateUser()
        {
            var user = new UserAccount { Uconst = "1", UserName = "UnitTestUser", Email = "UnitTest@Email.com", Birthdate = new DateTime(1986 - 10 - 10), Password = "CantBeHacked" };
            var (result, _) = PostData($"{UserApi}/Register?Uconst={user.Uconst}&UserName={user.UserName}&Email={user.Email}&Birthdate=1986-10-10&Password={user.Password}", user);
            UserAccount returnedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));

            returnedUser.UserName = "UpdatedUsername";

            var updatedStatusCode = PutData($"{UserApi}/Update?Uconst={returnedUser.Uconst}&UserName={returnedUser.UserName}&Email={returnedUser.Email}&Birthdate=1986-10-10&Password={returnedUser.Password}", returnedUser);

            var (result2, statusCode3) = GetObject($"{UserApi}/{returnedUser.Uconst}");
            UserAccount updatedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result2));

            Assert.Equal("UpdatedUsername", updatedUser.UserName);
            Assert.Equal(HttpStatusCode.OK, updatedStatusCode);

            // Clean Up
            DeleteData($"{UserApi}/{returnedUser.Uconst}");
        }

        [Fact]
        public void GetUserFound()
        {
            var user = new UserAccount { Uconst = "1", UserName = "UnitTestUser", Email = "UnitTest@Email.com", Birthdate = new DateTime(1986 - 10 - 10), Password = "CantBeHacked" };
            var (result, sc) = PostData($"{UserApi}/Register?Uconst={user.Uconst}&UserName={user.UserName}&Email={user.Email}&Birthdate=1986-10-10&Password={user.Password}", user);
            UserAccount returnedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));

            var (result2, statusCode) = GetObject($"{UserApi}/{returnedUser.Uconst}");
            UserAccount returnedUser2 = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.Equal(returnedUser2.UserName, user.UserName);
            // Clean Up
            DeleteData($"{UserApi}/{returnedUser.Uconst}");
        }

        [Fact]
        public void GetUserNotFound()
        {
            var user = new UserAccount { Uconst = "1", UserName = "UnitTestUser", Email = "UnitTest@Email.com", Birthdate = new DateTime(1986 - 10 - 10), Password = "CantBeHacked" };
            var (result, sc) = PostData($"{UserApi}/Register?Uconst={user.Uconst}&UserName={user.UserName}&Email={user.Email}&Birthdate=1986-10-10&Password={user.Password}", user);
            UserAccount returnedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));
            var invalidId = Int32.Parse(returnedUser.Uconst) + 1;
            var (result2, statusCode) = GetObject($"{UserApi}/{invalidId}");
            Assert.Equal(HttpStatusCode.NotFound, statusCode);

            // Clean Up
            DeleteData($"{UserApi}/{returnedUser.Uconst}");
        }

        [Fact]
        public void DeleteUser()
        {
            var user = new UserAccount { Uconst = "1", UserName = "UnitTestUser", Email = "UnitTest@Email.com", Birthdate = new DateTime(1986 - 10 - 10), Password = "CantBeHacked" };
            var (result, statusCode) = PostData($"{UserApi}/Register?Uconst={user.Uconst}&UserName={user.UserName}&Email={user.Email}&Birthdate=1986-10-10&Password={user.Password}", user);
            UserAccount returnedUser = JsonConvert.DeserializeObject<UserAccount>(JsonConvert.SerializeObject(result));
            var deleteResult = DeleteData($"{UserApi}/{returnedUser.Uconst}");
            Assert.Equal(HttpStatusCode.OK, deleteResult);


        }

        // Helpers
        // Borrowed from Henrik Bulskov
        //We had to add authentication to the header in order for it to work with our authentication

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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var response = client.GetAsync(url).Result;
            var data = response.Content.ReadAsStringAsync().Result;
            return ((JObject)JsonConvert.DeserializeObject(data), response.StatusCode);
        }

        (JObject, HttpStatusCode) PostData(string url, object content)
        {
            var client = new HttpClient();


            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);

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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
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
            client.DefaultRequestHeaders.Authorization = new AuthenticationHeaderValue("Bearer", bearerToken);
            var response = client.DeleteAsync(url).Result;
            return response.StatusCode;
        }
    }
}