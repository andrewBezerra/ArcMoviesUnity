using ArcMoviesUnity.Droid;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace ArcMoviesUnity.Views
{
    [Preserve]
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MasterPage : MasterDetailPage
    {
        public MasterPage()
        {
            InitializeComponent();
        }
    }
}