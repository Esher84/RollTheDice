using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using RollTheDice.Utilities;

namespace RollTheDice.ViewModels
{
    public class MainWindowViewModel : ViewModelBase
    {
        public MainWindowViewModel()
        {
            Players = new ObservableCollection<PlayerViewModel>();

            AddNewPlayerCommand = new RelayCommand<object>(action => AddNewPlayer(), canExecute => CanAddNewPlayer());
            RemovePlayerCommand = new RelayCommand<object>(action => RemovePlayer(), canExecute => CanRemovePlayer());
        }

        public ObservableCollection<PlayerViewModel> Players { get; private set; }
        public ICommand AddNewPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }

        public PlayerViewModel SelectedPlayer
        {
            get { return _selectedPlayer; }
            set
            {
                _selectedPlayer = value;
                OnPropertyChanged();
            }
        }

        private PlayerViewModel _selectedPlayer;
        public bool CanAddNewPlayer()
        {
            return Players.Count < 6;
        }

        private void AddNewPlayer()
        {
            PlayerViewModel newPlayer = new PlayerViewModel();
            Players.Add(newPlayer);
            SelectedPlayer = newPlayer;
            OnPropertyChanged("SelectedPlayer");
        }

        private bool CanRemovePlayer()
        {
            return this.SelectedPlayer != null;
        }

        private void RemovePlayer()
        {
            Players.Remove(this.SelectedPlayer);
        }
    }
}
