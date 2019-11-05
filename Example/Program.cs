using System;
using ViewModel;

namespace Example
{
    class Program
    {
        static void Main(string[] args)
        {
            var browser = new BrowserViewModel();
            browser.UploadNameSpaces(@"C:\Users\lenovo\source\repos\MPP-lab2.Faker1\Faker\bin\Debug\netcoreapp3.0");
            if (browser.NameSpaces == null)
                Console.WriteLine("dsda");
        }
    }
}
