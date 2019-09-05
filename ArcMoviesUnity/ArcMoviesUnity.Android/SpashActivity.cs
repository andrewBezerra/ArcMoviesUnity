using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace ArcMoviesUnity.Droid
{
    [Activity(Theme = "@style/ArcMovies.Splash", MainLauncher = true, NoHistory = true)]
    public class SpashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            StartActivity(new Intent(Application.Context, typeof(MainActivity)));
            Finish();
        }
    }
}