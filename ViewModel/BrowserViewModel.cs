using Model;
using System;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;

namespace ViewModel
{

    public class BrowserViewModel
    {

        private ObservableCollection<NameSpace> _nameSpaces { get; set; }
        public ObservableCollection<NameSpace> NameSpaces
        {
            get { return _nameSpaces; }
            set
            {
                _nameSpaces = value;
            }
        }

        public void UploadNameSpaces(string path)
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


    }
}
