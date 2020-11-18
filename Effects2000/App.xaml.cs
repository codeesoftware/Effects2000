using Effects2000.ViewModels;
using System.Windows;

namespace Effects2000
{
    /// <summary>
    /// Interaction logic for App.xaml
    /// </summary>
    public partial class App : Application
    {
        private MainViewModel mainViewModel;
        private Window mainView;


        protected override void OnStartup(StartupEventArgs e)
        {
            base.OnStartup(e);

            mainViewModel = new MainViewModel();

            mainView = new MainWindow();
            mainView.DataContext = mainViewModel;
            mainView.Show();


        }
    }
}
