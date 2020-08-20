using ArcMoviesUnity.Droid;
using ArcMoviesUnity.Models;
using Prism.Navigation;
using Prism.Services;
using System.Threading.Tasks;

namespace ArcMoviesUnity.ViewModels
{
    [Preserve(AllMembers =true)]
    public sealed class MovieDetailsPageViewModel : ViewModelBase
    {
        //private ITheMovieDBAPIService _TheMovieDBAPIService;
        private Movie _movie;
        public Movie Movie
        {
            get => _movie;
            set => SetProperty(ref _movie, value);
        }
       
        public MovieDetailsPageViewModel(INavigationService navigationService, IPageDialogService pagedialogservice) : base(navigationService, pagedialogservice)
        {
            Title = "Details";
        }
        public override async void OnNavigatedTo(INavigationParameters parameters)
        {
            isBusy = true;
            await Task.Run(() =>
            {
                Movie=parameters.GetValue<Movie>("movie");
                Title = Movie.Title;
            });
            isBusy = false;

        }
     

    }
}
