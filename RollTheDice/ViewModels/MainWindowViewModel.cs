using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Linq;
using System.Security.RightsManagement;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Threading;
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
            RollDiceCommand = new RelayCommand<object>(action => RollDice());
        }

        public ObservableCollection<PlayerViewModel> Players { get; private set; }
        public ICommand AddNewPlayerCommand { get; private set; }
        public ICommand RemovePlayerCommand { get; private set; }
        public ICommand RollDiceCommand { get; private set; }

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

        private void RollDice()
        {
            Random rnd = new Random();
            ThreadPool.QueueUserWorkItem((o) =>
            {
                for (int i = 1; i <= 10; i++)
                {
                    Dispatcher.CurrentDispatcher.Invoke((Action)(() => SetDice(rnd.Next(1, 7))));
                    Thread.Sleep(100 + 10 * i);
                }
            });


        }

        public bool IsOneOneVisible { get; set; }
        public bool IsThreeOneVisible { get; set; }
        public bool IsOneTwoVisible { get; set; }
        public bool IsTwoTwoVisible { get; set; }
        public bool IsThreeTwoVisible { get; set; }
        public bool IsOneThreeVisible { get; set; }
        public bool IsThreeThreeVisible { get; set; }

        private void SetDice(int rollResult)
        {
            try
            {
                switch (rollResult)
                {
                    case 1:
                        IsOneOneVisible = false;
                        IsThreeOneVisible = false;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = true;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = false;
                        IsThreeThreeVisible = false;
                        break;
                    case 2:
                        IsOneOneVisible = true;
                        IsThreeOneVisible = false;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = false;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = false;
                        IsThreeThreeVisible = true;
                        break;
                    case 3:
                        IsOneOneVisible = true;
                        IsThreeOneVisible = false;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = true;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = false;
                        IsThreeThreeVisible = true;
                        break;
                    case 4:
                        IsOneOneVisible = true;
                        IsThreeOneVisible = true;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = false;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = true;
                        IsThreeThreeVisible = true;
                        break;
                    case 5:
                        IsOneOneVisible = true;
                        IsThreeOneVisible = true;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = true;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = true;
                        IsThreeThreeVisible = true;
                        break;
                    case 6:
                        IsOneOneVisible = true;
                        IsThreeOneVisible = true;
                        IsOneTwoVisible = true;
                        IsTwoTwoVisible = false;
                        IsThreeTwoVisible = true;
                        IsOneThreeVisible = true;
                        IsThreeThreeVisible = true;
                        break;
                    default:
                        IsOneOneVisible = false;
                        IsThreeOneVisible = false;
                        IsOneTwoVisible = false;
                        IsTwoTwoVisible = false;
                        IsThreeTwoVisible = false;
                        IsOneThreeVisible = false;
                        IsThreeThreeVisible = false;
                        break;
                }
            }
            finally
            {
                OnPropertyChanged("IsOneOneVisible");
                OnPropertyChanged("IsThreeOneVisible");
                OnPropertyChanged("IsOneTwoVisible");
                OnPropertyChanged("IsTwoTwoVisible");
                OnPropertyChanged("IsThreeTwoVisible");
                OnPropertyChanged("IsOneThreeVisible");
                OnPropertyChanged("IsThreeThreeVisible");
            }
        }
    }
}
