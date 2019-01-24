using System;
using System.Collections.Generic;
using System.Text;
using System.Windows.Input;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Threading.Tasks;
using Xamarin.Forms;
namespace LoadList
{
    public class LoadingViewModel: INotifyPropertyChanged
    {
        public event PropertyChangedEventHandler PropertyChanged;
        void OnPropertyChanged([CallerMemberName] string name = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(name));
        }

        public ObservableCollection<string> ItemsList { get; }
        = new ObservableCollection<string>();
        public Command RefreshCommand { get; set; }
        public int LastInList=0;
        private bool isloading;
        public bool LoadingAct
        {
            get { return isloading; }
            set { isloading = value;
                OnPropertyChanged();
                OnPropertyChanged(nameof(LoadingAct));
            }
        }
        
        public LoadingViewModel()
        {
            for (int i = 1; i <= 30; i++)
            {
                ItemsList.Add($"Número de item: {i}");
                LastInList = i;
            }
            RefreshCommand = new Command(async () => await LoadindActivityChange());
        }
        async Task LoadindActivityChange()
        {
            LoadingAct = true;
            await Task.Delay(2000);
            int Add30 = LastInList + 30;
            for (int i = LastInList; i <= Add30; i++)
            {
                ItemsList.Add($"Nuevo número de item: {i}");
                LastInList= i;
            }
            LoadingAct = false;
        }
    }
}
