using ViewModel;

namespace Exmpl
{
    class Program
    {
        static void Main(string[] args)
        {
            var viewModel = new BrowserViewModel();
            viewModel.UploadNameSpaces(@"C: \Users\lenovo\source\repos\lr3AssemblyBrowser\Plugins");
        }
    }
}
