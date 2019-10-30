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
                        Console.WriteLine("here");
                        FolderBrowserDialog dialog = new FolderBrowserDialog();
                        if(dialog.ShowDialog() == DialogResult.OK)
                        {
                            UploadNameSpaces(dialog.SelectedPath);
                            Console.WriteLine(NameSpaces.Count);
                        }
                    }));
            }
        }

        public BrowserViewModel()
        {
            //NameSpaces = new ObservableCollection<NameSpace>();
            //UploadNameSpaces(@"C:\Users\Filip.Markovich\Source\Repos\MPP-lab2.Faker11111\Faker\bin\Debug\netcoreapp3.0");
        }


        private void UploadNameSpaces(string path)
        {
            ObservableCollection<NameSpace> nameSpaces = new ObservableCollection<NameSpace>();
            var pluginDirectory = new DirectoryInfo(path);
 
            if (pluginDirectory.Exists)
            {
                string[] pluginFiles = Directory.GetFiles(path, "*.dll");
                foreach (var file in pluginFiles)
                {
                    Console.WriteLine(file);
                    Assembly assembly = Assembly.LoadFrom(new FileInfo(file).FullName);
                    Type[] types = assembly.GetTypes();
                    Console.WriteLine(types.Length);
                    foreach (var type in types)
                    {

                        if (GetNameSpaceObjIfExist(nameSpaces, type.Namespace, out NameSpace nameSpace))
                        {
                            nameSpace.Classes.Add(new Class(type));
                        }
                        else
                        {
                            nameSpace.Classes.Add(new Class(type));
                        }
                    }
                }
                Console.WriteLine(nameSpaces.Count);
                NameSpaces = nameSpaces;
                foreach(var ns in NameSpaces)
                {
                    Console.WriteLine(ns.Name);
                }
            }
        }

        private bool GetNameSpaceObjIfExist(ObservableCollection<NameSpace> nameSpaces, String name, out NameSpace nameSpace)
        {
            NameSpace ns = nameSpaces.Where(t => t.Name == name).FirstOrDefault();
            if (ns != null)
            {
                nameSpace = ns;
                return true;
            }
            else
            {
                nameSpace = new NameSpace(name);
                nameSpaces.Add(nameSpace);
                return false;
            }
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
