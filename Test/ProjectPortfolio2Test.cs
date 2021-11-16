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
        private const string ActorsApi = "https://localhost:5001/api/actors";
        private const string GenresApi = "https://localhost:5001/api/genres";

        /* --------------------------- Title Tests --------------------------- */

        [Fact]
        public void Title_Object_HasTconstAndPrimarytitle()
        {
            var title = new Title();
            Assert.Null(title.Primarytitle);
            Assert.Null(title.Tconst);
        }

        [Fact]
        public void ApiTitles_GetWithNoArguments_OkAndFirst25Titles()
        {
            var (data, statusCode) = GetObject(TitlesApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data["results"]);
            Assert.Equal(25, data["results"].Count());
            Assert.Equal("Çocuk", data["results"].First()["primarytitle"]);
            Assert.Equal("Sunday", data["results"].Last()["primarytitle"]);
        }

        [Fact]
        public void ApiTitles_Get2ndPage_OkAndFirst25TitlesOfPage2()
        {
            var (data, statusCode) = GetObject(TitlesApi + "?page=2");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data["results"]);
            Assert.Equal(25, data["results"].Count());
            Assert.Equal("Planet Earth", data["results"].First()["primarytitle"]);
            Assert.Equal("Anne with an E", data["results"].Last()["primarytitle"]);
        }

        [Fact]
        public void ApiTitles_GetWithTconst_OkAndAllTitleDetails()
        {
            var (data, statusCode) = GetObject(TitlesApi + "/tt0816692");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal("Interstellar", data["primarytitle"]);
            Assert.NotEmpty(data["genreList"]);
            Assert.Equal("Sci-Fi", data["genreList"][1]["name"]);
        }

        [Fact]
        public void ApiTitles_GetActorsWithTconst_OkAndAllActorsFromTitle()
        {
            var (data, statusCode) = GetArray(TitlesApi + "/tt0816692/actors");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal("Hans Zimmer", data[3]["primaryname"]);
        }

        [Fact]
        public void ApiTitles_WithSearchQuery_OkAndSearchResults()
        {
            var (data, statusCode) = GetArray(TitlesApi + "/search?query=Mad%20Max");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal(3, data.Count);
            Assert.Equal("Mad Max: Fury Road", data[1]["primarytitle"]);
        }

        [Fact]
        public void ApiTitles_WithRatedSearchQuery_OkAndSearchResults()
        {
            var (data, statusCode) = GetArray(TitlesApi + "/ratedsearch?query=mads&query=ivan&query=apples");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal("Adam's Apples", data[0]["primarytitle"]);
        }

        /* --------------------------- Actor Tests --------------------------- */

        [Fact]
        public void Actor_Object_HasNconstAndPrimaryname()
        {
            var actor = new Actor();
            Assert.Null(actor.Primaryname);
            Assert.Null(actor.Nconst);
        }

        [Fact]
        public void ApiActors_GetActor_OkAndActorDetails()
        {
            var (data, statusCode) = GetObject(ActorsApi + "/nm0001877");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal("Hans Zimmer", data["primaryname"]);
        }

        [Fact]
        public void ApiActors_GetWithNonExistentNconst_404NotFound()
        {
            var (_, statusCode) = GetObject(ActorsApi + "/nm0000000");
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        /* --------------------------- Genre Tests --------------------------- */

        [Fact]
        public void Genre_Object_HasGenreIdAndName()
        {
            var genre = new Genre();
            Assert.Null(genre.Name);
            Assert.Equal(0, genre.Id);
        }

        [Fact]
        public void ApiGenres_GetWithNoArguments_OkAndFirst25Genres()
        {
            var (data, statusCode) = GetObject(GenresApi);
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data["results"]);
            Assert.Equal(25, data["results"].Count());
            Assert.Equal("Short", data["results"].First()["name"]);
            Assert.Equal("Musical", data["results"].Last()["name"]);
        }

        [Fact]
        public void ApiGenres_GetWithGenreId_OkAndGenreDetails()
        {
            var (data, statusCode) = GetObject(GenresApi + "/10");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data);
            Assert.Equal("Western", data["name"]);
            Assert.NotNull(data["titles"]);
        }

        [Fact]
        public void ApiGenres_GetWithNonExistentGenreId_404NotFound()
        {
            var (_, statusCode) = GetObject(GenresApi + "/30");
            Assert.Equal(HttpStatusCode.NotFound, statusCode);
        }

        [Fact]
        public void ApiGenres_GetTitlesByGenre_OkAndAllWesternTitles()
        {
            var (data, statusCode) = GetObject(GenresApi + "/10/titles");
            Assert.Equal(HttpStatusCode.OK, statusCode);
            Assert.NotEmpty(data["results"]);
            Assert.Equal(25, data["results"].Count());
            Assert.Equal("Guardians of the Clouds", data["results"].First()["primarytitle"]);
            Assert.Equal("Velvet Cut", data["results"].Last()["primarytitle"]);
        }


        /* --------------------------- Bookmark Tests --------------------------- */


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
            HttpClientHandler clientHandler = new HttpClientHandler();
            clientHandler.ServerCertificateCustomValidationCallback = (sender, cert, chain, sslPolicyErrors) => { return true; };
            var client = new HttpClient(clientHandler);
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