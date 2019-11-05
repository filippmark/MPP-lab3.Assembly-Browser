using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;

namespace Model
{
    public class NameSpaces
    {

       
        public NameSpaces()
        {

        }


        public ObservableCollection<NameSpace> UploadNameSpaces(string path)
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
                return nameSpaces;
            }
            return null;
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
