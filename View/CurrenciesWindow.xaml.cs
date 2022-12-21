using CryptoDBApp.ViewModel;
using System.Windows;

namespace CryptoDBApp.View
{
    /// <summary>
    /// Interaction logic for CurrenciesWindow.xaml
    /// </summary>
    public partial class CurrenciesWindow : Window
    {
        public CurrenciesWindow()
        {
            InitializeComponent();
            DataContext = new DataManageVM();
        }
    }
}
