using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using System.Windows.Markup.Localizer;
using System.Windows.Media;
using RollTheDice.Utilities;

namespace RollTheDice.ViewModels
{
    public class PlayerViewModel : ViewModelBase
    {
        public PlayerViewModel()
        {
            PlayerName = "New Player";
            PlayerLevel = 1;

            IncreasePlayerLevelCommand = new RelayCommand<object>(action => IncreaseOrDecreasePlayerLevel(true), canExecute => CanIncreaseOrDecreasePlayerLevel(true));
            DecreasePlayerLevelCommand = new RelayCommand<object>(action => IncreaseOrDecreasePlayerLevel(false), canExecute => CanIncreaseOrDecreasePlayerLevel(false));
        }

        public ICommand IncreasePlayerLevelCommand { get; private set; }
        public ICommand DecreasePlayerLevelCommand { get; private set; }

        public string PlayerName { get; set; }
        public int PlayerLevel { get; set; }

        private bool CanIncreaseOrDecreasePlayerLevel(bool increase)
        {
            return (increase && PlayerLevel < 10) || (!increase && PlayerLevel > 1);
        }

        public Brush Background { get; set; }

        private void IncreaseOrDecreasePlayerLevel(bool increase)
        {
            if (increase)
            {
                PlayerLevel++;

            }
            else
            {
                PlayerLevel--;
            }

            SetBackground();
            OnPropertyChanged("PlayerLevel");
        }

        private void SetBackground()
        {
            if (PlayerLevel >= 9)
            {
                Background = Brushes.Red;
            }
            else if (PlayerLevel >= 6)
            {
                Background = Brushes.LightCoral;
            }
            else if (PlayerLevel >= 3)
            {
                Background = Brushes.Yellow;
            }
            else
            {
                Background = Brushes.White;

            }


            OnPropertyChanged("Background");
        }
    }
}
