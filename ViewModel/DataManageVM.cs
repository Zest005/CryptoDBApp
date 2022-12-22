using CryptoDBApp.Model;
using CryptoDBApp.View;
using System.Collections.Generic;
using System.ComponentModel;
using System.Windows;

namespace CryptoDBApp.ViewModel
{
    public class DataManageVM : INotifyPropertyChanged
    {
        #region All Currencies List
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
        #endregion

        #region Temp List for Search
        private List<CryptocurrFullList> tempList = DataWorker.GetFullList();
        public List<CryptocurrFullList> TempList
        {
            get
            {
                return tempList;
            }
            set
            {
                tempList = value;
            }
        }
        #endregion

        #region TOP10 List
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
        #endregion

        #region Relay Commands
        private RelayCommand openCurrWindow;
        public RelayCommand OpenCurrsWindow
        {
            get
            {
                return openCurrWindow ?? new RelayCommand(obj =>
                {
                    OpeningCurrenciesWindow();
                });
            }
        }

        private RelayCommand openMainWindow;
        public RelayCommand OpenMainWindow
        {
            get
            {
                return openMainWindow ?? new RelayCommand(obj =>
                {
                    OpeningMainWindow();
                });
            }
        }

        private RelayCommand closeApp;
        public RelayCommand CloseApp
        {
            get
            {
                return closeApp ?? new RelayCommand(obj =>
                {
                    CloseApplication();
                });
            }
        }

        private RelayCommand searchComm;
        public RelayCommand SearchComm
        {
            get
            {
                return searchComm ?? new RelayCommand(obj =>
                {
                    SearchingInList();
                });
            }
        }
        #endregion

        #region Searching
        private string textSearch;
        public string TextSearch
        {
            get
            {
                return this.textSearch;
            }
            set
            {
                if (!string.Equals(this.textSearch, value))
                {
                    this.textSearch = value;
                }
            }
        }

        private void SearchingInList()
        {
            List<CryptocurrFullList> SearchCrypto = new List<CryptocurrFullList>();

            foreach (var item in TempList)
            {
                if (item.Id == TextSearch || item.Currency == TextSearch || item.Digest == TextSearch)
                    SearchCrypto.Add(item);
                else if (TextSearch == "" && FullCryptocurrs.Count < 100)
                {
                    FullCryptocurrs = TempList;
                    break;
                }
                else
                {
                    continue;
                }

                FullCryptocurrs = SearchCrypto;
                break;
            }
        }
        #endregion

        #region Windows buttons
        private void OpeningCurrenciesWindow()
        {
            var currenciesWindow = new CurrenciesWindow();
            currenciesWindow.Owner = Application.Current.MainWindow;
            currenciesWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            currenciesWindow.Show();
            App.Current.Windows[0].Hide();
        }

        private void OpeningMainWindow()
        {
            var mainWindow = new MainWindow();
            mainWindow.Owner = Application.Current.MainWindow;
            mainWindow.WindowStartupLocation = WindowStartupLocation.CenterOwner;
            mainWindow.Show();
            App.Current.Windows[0].Hide();
        }

        private void CloseApplication()
        {
            Application.Current.Shutdown();
        }
        #endregion

        #region Notify Property
        public event PropertyChangedEventHandler? PropertyChanged;

        private void NotifyPropertyChanged(string propertyName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propertyName));
            }
        }
        #endregion
    }
}
