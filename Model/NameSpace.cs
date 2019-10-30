using System.Collections.ObjectModel;
using System.ComponentModel;

namespace Model
{
    public class NameSpace : INotifyPropertyChanged
    {

        public string Name { get; set; }

        public ObservableCollection<Class> Classes { get; set; }

        public NameSpace(string name)
        {

            Name = name;
            Classes = new ObservableCollection<Class>();
        }

        public event PropertyChangedEventHandler PropertyChanged = delegate { };
        private void OnPropertyChanged(string name)
        {
            PropertyChangedEventHandler handler = PropertyChanged;
            handler(this, new PropertyChangedEventArgs(name));
        }
    }
}
