using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.Model
{
    public class DataWorker
    {
        public static Cryptocurr GetCurrency(string id, int rank, string currency, string digest, double price, double change, double volume, double marketCap)
        {
            return new Cryptocurr(id, rank, currency, digest, price, change, volume, marketCap);
        }
    }
}
