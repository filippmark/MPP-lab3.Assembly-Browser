using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Text;

namespace Model
{
    public class Class
    {

        public string Name { get; set; }
        
        public ObservableCollection<Field> Fields { get; set; }

        public ObservableCollection<Method> Methods { get; set; }

        public Class(string name)
        {
            Name = name;
            Fields = new ObservableCollection<Field>();
            Methods = new ObservableCollection<Method>();
        }
    }
}
