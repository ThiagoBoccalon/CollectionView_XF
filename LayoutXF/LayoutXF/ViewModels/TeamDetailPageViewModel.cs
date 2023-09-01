using LayoutXF.Models;
using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.Linq;

namespace LayoutXF.ViewModels
{
    public class TeamDetailPageViewModel : BindableBase
    {
        public Team SelectedItem { get; set; }


        public TeamDetailPageViewModel(Team team)
        {
            SelectedItem = team;
        }
    }
}
