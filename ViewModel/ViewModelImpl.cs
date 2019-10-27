using Model;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace ViewModel
{
    
    public class ViewModelImpl 
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

                        if(GetNameSpaceObjIfExist(nameSpaces, type.Namespace, out NameSpace nameSpace))
                        {

                        }
                        else
                        {
                            nameSpace = new NameSpace(type.Namespace);
                           
                        }
                    }
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
                nameSpace = null;
                return false;
            }
        }

        private void AddProperties(Type type, Dictionary<string, object> initialized, object dto)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance);
            foreach (var property in properties)
            {
                if (property.CanWrite && (!initialized.ContainsKey(property.Name)))
                {
                    property.SetValue(dto, GenerateValue(property.PropertyType));
                }
            }
        }
    }
}
