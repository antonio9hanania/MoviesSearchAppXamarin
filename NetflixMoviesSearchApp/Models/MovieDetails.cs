using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Reflection;
using System.Text;


namespace NetflixMoviesSearchApp.Models
{
    public class MovieDetails
    {
        private const string _ImageUrl = "https://image.tmdb.org/t/p/original/";
        private string _ReleaseDate;
        private string _PosterPath;
        private string _title;
        private const string NoImageFoundUrl = "https://upload.wikimedia.org/wikipedia/commons/thumb/a/ac/No_image_available.svg/1024px-No_image_available.svg.png";


        [JsonProperty("id")]
        public int ID { get; set; }
        [JsonProperty("title")]
        public string Title
        {
            get
            {
                return _title;
            }
            set
            {
                if (_title != value)
                    _title = value;
                //OnPropertyChanged();
            }

        }

        [JsonProperty("release_date")]
        public string Year
        {
            get
            {
                if (_ReleaseDate != "")
                    return _ReleaseDate.Substring(0, 4);
                else
                    return _ReleaseDate;
            }
            set
            {
                _ReleaseDate = value;
            }
        }

        [JsonProperty("poster_path")]
        public string ImageUrl
        {
            get
            {
                if (_PosterPath != null)
                    return _ImageUrl + _PosterPath.Substring(1);
                else
                    return NoImageFoundUrl;
                
            }
            set
            {
                _PosterPath = value;
            }
        }

        [JsonProperty("overview")]
        public string Overview { get; set; }


    }
}
