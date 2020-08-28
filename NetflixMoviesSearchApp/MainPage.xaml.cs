using NetflixMoviesSearchApp.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using static Xamarin.Forms.LayoutOptions;

namespace NetflixMoviesSearchApp
{
    public partial class MainPage : ContentPage
    {
        //private MainViewModel infListViewModel;
        private DataService _dataService;
        private MainViewModel mainViewModel = new MainViewModel();
        private MoviesListView ResListView = new MoviesListView();
        private Label NotFoundLabel = new Label() { Text = "No information found", FontSize = 33, HorizontalOptions = LayoutOptions.Center, VerticalOptions = LayoutOptions.Center };

        public MainPage()
        {
            InitializeComponent();
            ResListView.BindingContext = mainViewModel;
        }

        private async void searchBar_SearchButtonPressed(object sender, EventArgs e)
        {
            mainViewModel.Init();
            ScreenLayout.Children.Remove(NotFoundLabel);
            ScreenLayout.Children.Add(ResListView);
            _dataService = new DataService();
            int resSize = await _dataService.PopulateMovies(searchBar.Text);


            if (resSize > 0)
            {
                mainViewModel.Init();
                mainViewModel.NewContent(_dataService);
            }
            else
            {
                ResListView.IsRefreshing = false;
                ScreenLayout.Children.Remove(ResListView);
                ScreenLayout.Children.Add(NotFoundLabel);
            }

        }

        private void Button_Clicked(object sender, EventArgs e)
        {
            searchBar.Text = String.Empty;
        }
    }

}