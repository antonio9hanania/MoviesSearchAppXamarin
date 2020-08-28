using System;
using System.Collections.Generic;
using System.Text;
using Newtonsoft.Json;
using NetflixMoviesSearchApp.Models;
using System.Net.Http;
using System.Threading.Tasks;
using System.Linq;
using System.Reflection;

namespace NetflixMoviesSearchApp
{
    public class DataService
    {

        private class Rootobject
        {
            [JsonProperty("results")]
            public List<MovieDetails> Movies { get; set; }
        }

        private List<MovieDetails> moviesFetched;
        private const string _QuerySearchUrl = "https://api.themoviedb.org/3/search/movie?api_key=";
        private const string _QuerySearchSentence = "&query=";
        private const string _PersonalTokenKey = "3ba27a5d6c13f34b58a3e31c2385b3cb";
        private HttpClient _client = new HttpClient();

        public int MoviesResCount { get; set; }
        public string UsersSearch { get; set; }

        public async Task<int> PopulateMovies(string userSearch)
        {

            if (moviesFetched == null || moviesFetched.Count == 0)
            {
                var content = await _client.GetStringAsync(_QuerySearchUrl + _PersonalTokenKey + _QuerySearchSentence + userSearch);
                var response = JsonConvert.DeserializeObject<Rootobject>(content);

                moviesFetched = response.Movies;
                MoviesResCount = moviesFetched.Count;
            }
            return MoviesResCount;
        }



        public async Task<List<MovieDetails>> GetItemsAsync(int pageIndex, int pageSize)
        {
            await Task.Delay(1000);
            return moviesFetched.Skip(pageIndex * pageIndex).Take(pageSize).ToList();
        }
    }

}