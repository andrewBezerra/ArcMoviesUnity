using ArcMoviesUnity.Droid;
using System;
using Xamarin.Forms;

namespace ArcMoviesUnity.Views
{
    [Preserve]
    public partial class MainPage : ContentPage
    {
       
        public MainPage()
        {
            InitializeComponent();
            
        }
        protected override void OnDisappearing()
        {
            
           
            this.BindingContext = null;
            GC.Collect();
            GC.WaitForPendingFinalizers();
            GC.Collect();
            base.OnDisappearing();
        }


    }
}