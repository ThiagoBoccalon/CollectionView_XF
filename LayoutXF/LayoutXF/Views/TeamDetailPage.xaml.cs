using LayoutXF.Models;
using Xamarin.Forms;
using LayoutXF.ViewModels;

namespace LayoutXF.Views
{
    public partial class TeamDetailPage : ContentPage
    {
        public TeamDetailPage(Team team)
        {
            InitializeComponent();

            BindingContext = new TeamDetailPageViewModel(team);
        }
    }
}
