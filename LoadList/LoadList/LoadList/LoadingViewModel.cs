using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace LoadList
{
    public class LoadingViewModel
    {
        public ObservableCollection<string> FileNames { get; }
        = new ObservableCollection<string>();
        public LoadingViewModel()
        {
            for (int i = 0; i < 100; i++)
            {
                FileNames.Add($"Inserted item {i}");
            }
        }
    }
}
