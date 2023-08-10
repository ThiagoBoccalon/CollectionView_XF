using Prism.Commands;
using Prism.Mvvm;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using LayoutXF.Models;
using System.Collections.ObjectModel;
using System.Windows.Input;
using Xamarin.Forms;
using System.Runtime.CompilerServices;

namespace LayoutXF.ViewModels
{
    public class TeamsPageViewModel : BindableBase, INotifyPropertyChanged
    {
        readonly IList<Team> source;
        Team selectedTeam;
        int selectionCount = 1;

        public ObservableCollection<Team> Teams { get; private set; }
        public IList<Team> EmptyTeams { get; private set; }

        public Team SelectedTeam
        {
            get { return selectedTeam; }
            set
            {
                if(selectedTeam != value)
                {
                    selectedTeam = value;
                }
            }
        }

        ObservableCollection<object> selectedTeams;
        public ObservableCollection<object> SelectedTeams
        {
            get
            {
                return selectedTeams;
            }
            set
            {
                if(selectedTeams != value)
                {
                    selectedTeams = value;
                }
            }
        }

        public string SelectedTeamMessage { get; private set; }
        public ICommand FilterCommand => new Command<string>(FilterItems);
        public ICommand TeamSelectionChangedCommand => new Command(TeamSelectionChanged);

        public TeamsPageViewModel()
        {
            source = new List<Team>();
            CreateTeamCollection();

            selectedTeam = Teams.Skip(3).FirstOrDefault();
            TeamSelectionChanged();

            SelectedTeams = new ObservableCollection<object>
            {
                Teams[1], Teams[3], Teams[4]
            };

        }

        void FilterItems(string filter)
        {
            var itemsfilters = source.Where(team => team.Name.ToLower().Contains(filter.ToLower())).ToList();
            foreach(var team in source){
                if (!itemsfilters.Contains(team))
                {
                    Teams.Remove(team);
                }
                else
                {
                    if (!Teams.Contains(team))
                    {
                        Teams.Add(team);
                    }
                }
            }
        }

        void TeamSelectionChanged()
        {
            SelectedTeamMessage = string.Empty;
            OnPropertyChanged("SelectedTeamMessage");
            selectionCount++;
        }

        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private void CreateTeamCollection()
        {
            source.Add(new Team
            {
                Name = "Botafogo",
                ImageUrl = "botafogo.jpg",
                Points = 30,
                Details = "Rio de Janeiro"
            });
            source.Add(new Team
            {
                Name = "Santos",
                ImageUrl = "santos.jpg",
                Points = 29,
                Details = "Peixe - O time do Péle e da Vila Belmiro"
            });
            source.Add(new Team
            {
                Name = "Palmeiras",
                ImageUrl = "palmeiras.jpg",
                Points = 27,
                Details = "Porco - O alviverde paulista"
            });
            source.Add(new Team
            {
                Name = "Flamengo",
                ImageUrl = "flamengo.jpg",
                Points = 24,
                Details = "Urubu - O rubro-nego carioca"
            });
            source.Add(new Team
            {
                Name = "Atlético-MG",
                ImageUrl = "atletico_mg.jpg",
                Points = 21,
                Details = "Galo - O alvi-negro mineiro "
            });
            source.Add(new Team
            {
                Name = "São Paulo",
                ImageUrl = "sao_paulo.jpg",
                Points = 21,
                Details = "São Bento - São Paulo  "
            });            
            source.Add(new Team
            {
                Name = "Atlético-PR",
                ImageUrl = "atletico_pr.jpg",
                Points = 19,
                Details = "Paraná"
            });
            source.Add(new Team
            {
                Name = "Corinthians",
                ImageUrl = "corinthians.jpg",
                Points = 19,
                Details = "São Jorge - São Paulo"
            });

            Teams = new ObservableCollection<Team>(source);
        }
    }
}
