using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.Model
{
    public class Cryptocurr
    {
        public Cryptocurr(string id, string name, int rank, string symbol, double marketCapUsd, double priceUsd, double changePercent24Hr)
        {
            Id = id;
            Name = name;
            Rank = rank;
            Symbol = symbol;
            MarketCapUsd = marketCapUsd;
            PriceUsd = priceUsd;
            ChangePercent24Hr = changePercent24Hr;
        }

        public string Id { get; set; }

        public string Name { get; set; }

        public int Rank { get; set; }

        public string Symbol { get; set; }
        
        public double MarketCapUsd { get; set; }

        public double PriceUsd { get; set; }
        
        public double ChangePercent24Hr { get; set; }

        public static Cryptocurr CreateCryptocurr()
        {
            return new Cryptocurr();
        }
    }
}
