using Model;
using MVVM;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using Microsoft.Win32;
using System.Windows.Forms;
using System.ComponentModel;

namespace ViewModel
{

    public class BrowserViewModel : INotifyPropertyChanged
    {

        private ObservableCollection<NameSpace> _nameSpaces { get; set; }
        public ObservableCollection<NameSpace> NameSpaces
        {
            get { return _nameSpaces; }
            set
            {
                _nameSpaces = value;
                OnPropertyChanged("NameSpaces");
            }
        }

        
        private RelayCommand openCommand;
        public RelayCommand OpenCommand
        {
            get
            {
                return openCommand ??
                    (openCommand = new RelayCommand(obj =>
                    {
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if(dialog.ShowDialog() == DialogResult.OK)
                        {
                            var ns = new NameSpaces();
                            NameSpaces = ns.UploadNameSpaces(dialog.SelectedPath);
                            Console.WriteLine(NameSpaces.Count);
                        }
                    }));
            }
        }

        public BrowserViewModel()
        {

        }


        

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
