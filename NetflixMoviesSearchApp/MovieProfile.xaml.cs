using NetflixMoviesSearchApp.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace NetflixMoviesSearchApp
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieProfile : ContentPage
    {
        public MovieProfile(MovieDetails movie)
        {
            InitializeComponent();
            BindingContext = movie;
        }
    }
}