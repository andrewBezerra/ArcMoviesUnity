using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Models;
using ArcMoviesUnity.Services;
using ArcMoviesUnity.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArcMoviesUnity.ViewModels
{
    [Preserve(AllMembers = true)]
    public sealed class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<Movie> Movies { get; set; }




        private bool canLoadMore = true;

        public bool CanLoadMore
        {
            get => canLoadMore;
            set => SetProperty(ref canLoadMore, value);
        }

        //private DelegateCommand _fieldName;
        //public DelegateCommand<Movie> CommandName =>
        //    _fieldName ?? (_fieldName = new DelegateCommand<Movie>((itemselect)=>ExecuteCommandName(), (itemSelect) => !isBusy));

        //void ExecuteCommandName()
        //{

        //}



        private DelegateCommand<Movie> _ShowMovieCommand;
        public DelegateCommand<Movie> ShowMovieCommand =>
            _ShowMovieCommand ?? (_ShowMovieCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteShowMovieCommand(itemSelect), (itemSelect) => !isBusy));

        private DelegateCommand<Movie> _loadMoreCommand;
        public DelegateCommand<Movie> LoadMoreCommand =>
            _loadMoreCommand ?? (_loadMoreCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteLoadMoreCommand(itemSelect), (itemSelect) => !isBusy));

        private DelegateCommand _pullToRefreshCommand;
        public DelegateCommand PullToRefreshCommand =>
            _pullToRefreshCommand ?? (_pullToRefreshCommand = new DelegateCommand(async () =>
             await ExecutePullToRefreshCommand(), () => !isBusy));

        private readonly ITheMovieDBAPIService _TheMovieDBAPIService;

        private int _pageindex = 1;

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pagedialogservice, ITheMovieDBAPIService theMovieDBAPIService)
            : base(navigationService, pagedialogservice)
        {
            Title = "The Movies DB";
            _TheMovieDBAPIService = theMovieDBAPIService;
            Movies = new ObservableCollection<Movie>();
           
            _ = LoadAsync();
          
            Xamarin.Forms.BindingBase.EnableCollectionSynchronization(Movies, null, ObservableCollectionCallback);
        }
        void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        {
            // `lock` ensures that only one thread access the collection at a time
            lock (collection)
            {
                accessMethod?.Invoke();
            }
        }


        private async Task ExecuteShowMovieCommand(Movie movie)
        {
            try
            {
                isBusy = true;
                movie = await _TheMovieDBAPIService.FindByIdAsync(movie.Id);
                var navigationParams = new NavigationParameters
                {
                    {"movie", movie}
                };
                Movies = null;
                await NavigationService.NavigateAsync($"/MasterPage/NavigationPage/MainPage/{nameof(MovieDetailsPage)}", navigationParams);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movie:" + ex.Message, "OK");
            }
            finally
            {
                isBusy = false;
            }
        }
        private async Task ExecuteLoadMoreCommand(Movie item)
        {
            if (Movies[Movies.IndexOf(Movies.Last()) - 3] == item)
            {
                _pageindex++;
                await LoadAsync(_pageindex);
            }
        }
        private async Task ExecutePullToRefreshCommand()
        {
            Movies.Clear();
            _pageindex = 1;
           
            await LoadAsync();
         
        }

        private async Task LoadAsync(int page = 1)
        {
            isBusy = true;

            var movies = await _TheMovieDBAPIService.GetUpcomingMoviesAsync(page);

            await Task.Run(() =>
            {
                for (int c = 0; c < movies.Results.Count; c++)
                    Movies.Add(movies.Results[c]);
            });

            isBusy = false;
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            //base.OnNavigatingTo(parameters);
            await LoadAsync();
        }


    }
}
