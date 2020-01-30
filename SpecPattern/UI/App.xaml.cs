using Logica.Utils;
using System.Windows;

namespace UI
{
    /// <summary>
    /// Interaction Logica for App.xaml
    /// </summary>
    public partial class App : Application
    {
        public App()
        {
            Initer.Init(@"Server=(localdb)\MSSQLLocalDB;Database=SpecPattern;Trusted_Connection=true;");
        }
    }
}
