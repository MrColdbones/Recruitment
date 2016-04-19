using CountryTree.Infrastructure;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountryTree.ViewModels
{
    public class MainWindowViewModel : INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;

        public RelayCommand AddCountryCommand { get; set; }
        public RelayCommand RemoveCountryCommand { get; set; }

        public RelayCommand AddCountrySubregionCommand { get; set; }
        public RelayCommand RemoveCountrySubregionCommand { get; set; }

        public RelayCommand AddPossibleSubregionCommand { get; set; }
        public RelayCommand RemovePossibleSubregionCommand { get; set; }

        public MainWindow Window { get; set; }

        public MainWindowViewModel()
        {

        }

        public void PropChanged(string PropertyName)
        {
            if(this.PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(PropertyName));
            }
        }
    }
}
