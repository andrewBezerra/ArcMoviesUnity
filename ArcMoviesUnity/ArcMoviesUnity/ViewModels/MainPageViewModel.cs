using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Models;
using ArcMoviesUnity.Services;
using ArcMoviesUnity.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArcMoviesUnity.ViewModels
{
    [Preserve(AllMembers =true)]
    public sealed class MainPageViewModel : ViewModelBase
    {
        private ObservableCollection<Movie> _movies;
        public ObservableCollection<Movie> Movies
        {
            get { return _movies; }
            set { SetProperty(ref _movies, value); }
        }


        private DelegateCommand<Movie> _ShowMovieCommand;
        public DelegateCommand<Movie> ShowMovieCommand =>
            _ShowMovieCommand ?? (_ShowMovieCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteShowMovieCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand<Movie> _loadMoreCommand;
        public DelegateCommand<Movie> LoadMoreCommand =>
            _loadMoreCommand ?? (_loadMoreCommand = new DelegateCommand<Movie>(async (itemSelect) =>
            await ExecuteLoadMoreCommand(itemSelect), (itemSelect) => !IsBusy));

        private DelegateCommand _pullToRefreshCommand;
        public DelegateCommand PullToRefreshCommand =>
            _pullToRefreshCommand ?? (_pullToRefreshCommand = new DelegateCommand(async () =>
             await ExecutePullToRefreshCommand(), () => !IsBusy));

        private readonly ITheMovieDBAPIService _TheMovieDBAPIService;

        private int _pageindex = 1;

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pagedialogservice,ITheMovieDBAPIService theMovieDBAPIService)
            : base(navigationService, pagedialogservice)
        {
            Title = "The Movies DB";
            _TheMovieDBAPIService = theMovieDBAPIService;
            Movies = new ObservableCollection<Movie>();
        }
        //public override void Destroy()
        //{
        //    base.Destroy();
        //    _pullToRefreshCommand;
        //}



        private async Task ExecuteShowMovieCommand(Movie movie)
        {
            try
            {
                IsBusy = true;
                movie = await _TheMovieDBAPIService.FindByIdAsync(movie.Id);
                var navigationParams = new NavigationParameters
                {
                    {"movie", movie}
                };
                await NavigationService.NavigateAsync($"/MasterPage/NavigationPage/MainPage/{nameof(MovieDetailsPage)}", navigationParams);
            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movie:" + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        private async Task ExecuteLoadMoreCommand(Movie item)
        {
            if (Movies.Last() == item)
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
            try
            {
                IsBusy = true;

                var movies = await _TheMovieDBAPIService.GetUpcomingMoviesAsync(page);


                foreach (var movie in movies.Results)
                {
                    Movies.Add(movie);
                }

            }
            catch (Exception ex)
            {
                await PageDialogService.DisplayAlertAsync("Erro", "Error on Load Movies:" + ex.Message, "OK");
            }
            finally
            {
                IsBusy = false;
            }
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            //base.OnNavigatingTo(parameters);
            await LoadAsync();
        }


    }
}
