using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms.Extended;
using static NetflixMoviesSearchApp.DataService;
using NetflixMoviesSearchApp.Models;

namespace NetflixMoviesSearchApp
{
    public class MainViewModel : INotifyPropertyChanged
    {
        private bool _isBusy;
        private bool _isRefreshing;
        private const int PageSize = 10;
        private DataService _dataService;

        public event PropertyChangedEventHandler PropertyChanged;

        public InfiniteScrollCollection<MovieDetails> Movies { get; set; }

        public bool IsBusy
        {
            get => _isBusy;
            set
            {
                _isBusy = value;
                OnPropertyChanged();
            }
        }
        public bool IsRefreshing
        {
            get => _isRefreshing;
            set
            {
                _isRefreshing = value;
                OnPropertyChanged();
            }
        }
        public MainViewModel()
        {
            //_dataService = dataService;
            Movies = new InfiniteScrollCollection<MovieDetails>();
            //Movies = new InfiniteScrollCollection<MovieDetails>
            //{
            //    OnLoadMore = async () =>
            //    {
            //        IsBusy = true;
            //        var page = Movies.Count / PageSize;
            //        var movie = await _dataService.GetItemsAsync(page, PageSize);
            //        IsBusy = false;
            //        return movie;
            //    },
            //    OnCanLoadMore = () =>
            //    {
            //        return Movies.Count < 50;
            //    }
            //};
            //DownloadDataAsync();
        }
        private async Task DownloadDataAsync()
        {
            var items = await _dataService.GetItemsAsync(pageIndex: 0, pageSize: PageSize);
            Movies.AddRange(items);
            IsRefreshing = false;
        }
        protected virtual void OnPropertyChanged([CallerMemberName] string propertyname = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyname));
        }

        public void Init()
        {
            Movies.Clear();

            IsBusy = false;
            IsRefreshing = true;



        }
        public async void NewContent(DataService dataService)
        {
            _dataService = dataService;
            Movies.OnLoadMore += async () =>
            {
                IsBusy = true;
                var page = Movies.Count / PageSize;
                var movie = await _dataService.GetItemsAsync(page, PageSize);
                IsBusy = false;
                return movie;
            };
            Movies.OnCanLoadMore += () =>
            {
                return Movies.Count < 50;
            };

            await DownloadDataAsync();
            await Movies.LoadMoreAsync();

        }
    }
}
