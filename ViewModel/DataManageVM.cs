using CryptoDBApp.Model;
using CryptoDBApp.View;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using System.Windows;

namespace CryptoDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        // all currs
        private List<CryptocurrFullList> fullCryptocurrs = DataWorker.GetFullList();
        public List<CryptocurrFullList> FullCryptocurrs
        { 
            get
            {
                return fullCryptocurrs;
            }
            set
            {
                fullCryptocurrs = value;
                NotifyPropertyChanged("FullCryptocurrs");
            }
        }

        // top10
        private List<CryptocurrShortList> topCryptocurrs = DataWorker.GetShortList();

        public List<CryptocurrShortList> TopCryptocurrs
        {
            get
            {
                return topCryptocurrs;
            }
            set
            {
                topCryptocurrs = value;
                NotifyPropertyChanged("TopCryptocurrs");
            }
        }

        // buttons for MainWindow
        private void MainWindowClosing()
        {
            Application.Current.Shutdown();
        }

        private void OpenCurrenciesWindow(Window window)
        {
            CurrenciesWindow currenciesWindow = new CurrenciesWindow();
            currenciesWindow.Show();
            window.Close();
        }

        // buttons for CurrenciesWindow
        private void OpenMainWindow(Window window)
        {
            MainWindow mainWindow = new MainWindow();
            mainWindow.Show();
            window.Close();
        }

        private void CurrenciesWindowClosing()
        {
            Application.Current.Shutdown();
        }

        // NotifyProp
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
    }
}
