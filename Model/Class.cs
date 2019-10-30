using System;
using System.Collections;
using System.Collections.ObjectModel;
using System.Reflection;
using System.Windows.Data;

namespace Model
{
    public class Class
    {
        

        public string Name { get; set; }

        public ObservableCollection<Field> Fields { get; set; }

        public ObservableCollection<Method> Methods { get; set; }

        public ICollection Collection
        {
            get
            {
                return new CompositeCollection()
                {
                    new CollectionContainer() { Collection = Fields },
                    new CollectionContainer() { Collection = Methods }
                };
            }
        }

        public Class(Type type)
        {
            Name = type.Name;
            Fields = new ObservableCollection<Field>();
            Methods = new ObservableCollection<Method>();

            AddProperties(type);
            AddFields(type);
            AddMethods(type);
        }

        private void AddProperties(Type type)
        {
            PropertyInfo[] properties = type.GetProperties(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var property in properties)
            {
                string info = $"{property.PropertyType} {property.Name}";
                var field = new Field(info);
                Fields.Add(field);
            }
        }

        private void AddFields(Type type)
        {
            FieldInfo[] fields = type.GetFields(BindingFlags.Public | BindingFlags.Static | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var fieldInfo in fields)
            {
                string info = $"{fieldInfo.FieldType} {fieldInfo.Name}";
                var field = new Field(info);
                Fields.Add(field);
            }
        }

        private void AddMethods(Type type)
        {
            MethodInfo[] methods = type.GetMethods(BindingFlags.Public | BindingFlags.Instance | BindingFlags.NonPublic);
            foreach (var methodInfo in methods)
            {
                var method = new Method(methodInfo);
                Methods.Add(method);
            }
        }

    }
}
