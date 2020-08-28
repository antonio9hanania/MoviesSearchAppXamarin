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
    public partial class MoviesListView : ListView
    {
        public MoviesListView()
        {
            InitializeComponent();
        }

        private void ListView_ItemSelected(object sender, SelectedItemChangedEventArgs e)
        {
            Navigation.PushAsync(new MovieProfile(e.SelectedItem as MovieDetails));
        }
    }
}