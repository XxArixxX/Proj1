using OxyPlot;
using Proj1.Infrastracture.Commands;
using Proj1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows;
using System.Windows.Input;

namespace Proj1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Analize stats CV19";
        private string _downText = "|||";
        private int _progressLine = 30;

        private IEnumerable<DataPoint> _TestDataPoints;
        public IEnumerable<DataPoint> TestDataPoints { 
            get => _TestDataPoints; 
            set => Set(ref _TestDataPoints, value); }
        public string title
        {
            get => _title;
            // set
            //{
            // if (Equals(_title, value)) return;
            // _title = value;
            // OnPropertyChanged();

            //   Set(ref _title, value);
            //}
            set => Set(ref _title, value);
        }

        public int progressLine
        {
            get => _progressLine;
            // set
            //{
            // if (Equals(_title, value)) return;
            // _title = value;
            // OnPropertyChanged();

            //   Set(ref _title, value);
            //}
            set => Set(ref _progressLine, value);
        }

        public string downText
        {
            get => _downText;
            // set
            //{
            // if (Equals(_title, value)) return;
            // _title = value;
            // OnPropertyChanged();

            //   Set(ref _title, value);
            //}
            set => Set(ref _downText, value);
        }

        #region Status : string - Program status
        private string _Status = "Ready!";

        public string Status { get => _Status; set => Set(ref _Status, value); }
        #endregion

        #region Myregion
        public ICommand CloseApplicationCommand { get; }

        private void OnCloseApplicationCommandExecuted(object p)
        {
            Application.Current.Shutdown();
        }

        private bool CanCloseApplicationCommandExecute(object p) => true;
        #endregion
        public MainWindowViewModel()
        {
            #region commands
            CloseApplicationCommand = new LambdaCommands(OnCloseApplicationCommandExecuted, CanCloseApplicationCommandExecute);
            #endregion

            var data_points = new List<DataPoint>((int)(360 / 0.1));
            for(var x = 0d; x<= 360; x+= 0.1)
            {
                const double to_rad = Math.PI / 100;
                var y = Math.Sin(2 * Math.PI * x * to_rad);

                data_points.Add(new DataPoint { XValue = x, YValue = y });
            
            }

            TestDataPoints = data_points;
        }
    }
}
