using Prism;
using Prism.Ioc;
using ArcMoviesUnity.ViewModels;
using ArcMoviesUnity.Views;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using ArcMoviesUnity.Services;
using ArcMoviesUnity.Droid;
using Prism.Unity;
using System.Threading.Tasks;
using System;

[assembly: XamlCompilation(XamlCompilationOptions.Compile)]
namespace ArcMoviesUnity
{
    [Preserve]
    public partial class App:PrismApplication
    {
        /* 
         * The Xamarin Forms XAML Previewer in Visual Studio uses System.Activator.CreateInstance.
         * This imposes a limitation in which the App class must have a default constructor. 
         * App(IPlatformInitializer initializer = null) cannot be handled by the Activator.
         */
        public App() : this(null) { }

        public App(IPlatformInitializer initializer) : base(initializer) { }

        protected override async void OnInitialized()
        {
            await InitializeComponentsAsync();
            await NavigationService.NavigateAsync("/MasterPage/NavigationPage/MainPage");
        }
        protected async Task InitializeComponentsAsync()
        {
             await Task.Run(()=> InitializeComponent());
        }

        protected override void RegisterTypes(IContainerRegistry containerRegistry)
        {
            containerRegistry.RegisterForNavigation<NavigationPage>();
            containerRegistry.RegisterForNavigation<MasterPage>();
            containerRegistry.RegisterForNavigation<MainPage, MainPageViewModel>();
            containerRegistry.RegisterForNavigation<MovieDetailsPage, MovieDetailsPageViewModel>();

            containerRegistry.Register<IHttpRequest, FlurlHttpService>();
            containerRegistry.Register<ITheMovieDBAPIService, TheMovieDBAPIService>();

        }
    }
}
