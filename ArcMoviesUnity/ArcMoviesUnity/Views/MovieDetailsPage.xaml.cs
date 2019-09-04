using ArcMoviesUnity.Droid;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcMoviesUnity.Views
{
    [Preserve]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MovieDetailsPage : ContentPage
    {
        public MovieDetailsPage()
        {
            InitializeComponent();
        }

        protected override async void OnAppearing()
        {
            //  base.OnAppearing();
            await Task.Run(async () =>
           {
               await OverView.TranslateTo(0, -Application.Current.MainPage.Height, 0, null);
               await Task.Run(() =>
               {
                   Poster.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
                   Backdrop.TranslateTo(Application.Current.MainPage.Width + 20, 0, 1, null);
               });
               await ReleaseDate.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
               await VoteAverage.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
               await Genres.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
               await BackDropInfo.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);

           });
            OverView.IsVisible = true;
            Poster.IsVisible = true;
            Backdrop.IsVisible = true;
            ReleaseDate.IsVisible = true;
            VoteAverage.IsVisible = true;
            Genres.IsVisible = true;
            BackDropInfo.IsVisible = true;
            Backdrop.Opacity = 0.5;
            await Task.Run(async () =>
            {
                await OverView.TranslateTo(0, 0, 500, Easing.BounceOut);
                await Task.Run(() =>
                {
                    Poster.TranslateTo(0, 0, 1000, Easing.BounceOut);
                    Backdrop.TranslateTo(0, 0, 1000, Easing.BounceOut);
                });
                await ReleaseDate.TranslateTo(0, 0, 500, Easing.BounceOut);
                await VoteAverage.TranslateTo(0, 0, 500, Easing.BounceOut);
                await Genres.TranslateTo(0, 0, 500, Easing.BounceOut);
                await BackDropInfo.TranslateTo(0, 0, 500, Easing.BounceOut);
            });

        }
        protected override async void OnDisappearing()
        {
            await Task.Run(async () =>
            {
                await OverView.TranslateTo(0, -Application.Current.MainPage.Height, 1, null);
                await Task.Run(() =>
                {
                    Poster.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
                    Backdrop.TranslateTo(Application.Current.MainPage.Width + 20, 0, 1, null);
                });
                await ReleaseDate.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
                await VoteAverage.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
                await Genres.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
                await BackDropInfo.TranslateTo(-Application.Current.MainPage.Width + 20, 0, 1, null);
            });
        }
    }
}