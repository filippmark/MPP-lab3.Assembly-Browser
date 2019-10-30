using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model
{
    public class NameSpace
    {

        public string Name { get; set; }

        public ObservableCollection<Class> Classes { get; set; }

        public NameSpace(string name)
        {

            Name = name;
            Classes = new ObservableCollection<Class>();
        }

    }
}
