using Proj1.ViewModels.Base;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Proj1.ViewModels
{
    internal class MainWindowViewModel : ViewModel
    {
        private string _title = "Analize stats CV19";

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
    }
}
