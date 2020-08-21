using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Models;
using ArcMoviesUnity.Services;
using ArcMoviesUnity.Views;
using Prism.Commands;
using Prism.Navigation;
using Prism.Services;
using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Linq;
using System.Threading.Tasks;

namespace ArcMoviesUnity.ViewModels
{
    [Preserve(AllMembers = true)]
    public sealed class MainPageViewModel : ViewModelBase
    {
        public ObservableCollection<MovieListMainPageViewModel> Movies { get; set; }

        private bool _isShown = true;

        public bool isShown
        {
            get => _isShown;
            set => SetProperty(ref _isShown, value);
        }

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



        private DelegateCommand<MovieListMainPageViewModel> _ShowMovieCommand;
        public DelegateCommand<MovieListMainPageViewModel> ShowMovieCommand =>
            _ShowMovieCommand ?? (_ShowMovieCommand = new DelegateCommand<MovieListMainPageViewModel>(async (itemSelect) =>
            await ExecuteShowMovieCommand(itemSelect), (itemSelect) => !isBusy));

        private DelegateCommand<MovieListMainPageViewModel> _loadMoreCommand;
        public DelegateCommand<MovieListMainPageViewModel> LoadMoreCommand =>
            _loadMoreCommand ?? (_loadMoreCommand = new DelegateCommand<MovieListMainPageViewModel>(async (itemSelect) =>
            await ExecuteLoadMoreCommand(itemSelect), (itemSelect) => !isBusy));

        private DelegateCommand _pullToRefreshCommand;
        public DelegateCommand PullToRefreshCommand =>
            _pullToRefreshCommand ?? (_pullToRefreshCommand = new DelegateCommand(async () =>
             await ExecutePullToRefreshCommand(), () => !isBusy));

        private readonly Lazy<ITheMovieDBAPIService> _TheMovieDBAPIService;

        private int _pageindex = 1;

        public MainPageViewModel(INavigationService navigationService,
            IPageDialogService pagedialogservice, Lazy<ITheMovieDBAPIService> TheMovieDBAPIService)
            : base(navigationService, pagedialogservice)
        {
            Title = "The Movies DB";
            if (isShown)
            {
                _TheMovieDBAPIService = TheMovieDBAPIService;
                Movies = new ObservableCollection<MovieListMainPageViewModel>();

                _ = LoadAsync();
            }
           // Xamarin.Forms.BindingBase.EnableCollectionSynchronization(Movies, null, ObservableCollectionCallback);
        }
        //void ObservableCollectionCallback(IEnumerable collection, object context, Action accessMethod, bool writeAccess)
        //{
        //    // `lock` ensures that only one thread access the collection at a time
        //    lock (collection)
        //    {
        //        accessMethod?.Invoke();
        //    }
        //}


        private async Task ExecuteShowMovieCommand(MovieListMainPageViewModel movie)
        {
            try
            {
                //isBusy = true;
                var m = await _TheMovieDBAPIService.Value.FindByIdAsync(movie.Id);
                var navigationParams = new NavigationParameters
                {
                    {"movie", m}
                };
                _isShown = false;
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
        private async Task ExecuteLoadMoreCommand(MovieListMainPageViewModel item)
        {
            if (item.Equals(Movies[Movies.IndexOf(Movies.Last()) - 3]))
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

            var movies = await _TheMovieDBAPIService.Value.GetUpcomingMoviesAsync(page);

            await Task.Run(() =>
            {
                for (int c = 0; c < movies.Results.Count; c++)
                    Movies.Add(movies.Results[c]);
            });

            isBusy = false;
            
        }
        public override async void OnNavigatingTo(INavigationParameters parameters)
        {
            
            _isShown = true;
           //await LoadAsync();
            base.OnNavigatingTo(parameters);
        }
       

      

    }
}
