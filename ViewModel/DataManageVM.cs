using CryptoDBApp.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.ViewModel
{
    public class DataManageVM
    {
        // all currs
        private List<CryptocurrFullList> fullCryptocurrs = DataWorker.GetFullList();
        public List<CryptocurrFullList> FullCryptocurrs
        { 
            get
            {
                return fullCryptocurrs;
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
        }
    }
}
