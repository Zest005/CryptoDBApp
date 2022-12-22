using CryptoDBApp.ViewModel;
using System.Windows;
using System.Windows.Input;

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

        // Drag window
        private void Window_MouseDown(object sender, MouseButtonEventArgs e)
        {
            if (e.ChangedButton == MouseButton.Left)
                this.DragMove();
        }
    }
}
