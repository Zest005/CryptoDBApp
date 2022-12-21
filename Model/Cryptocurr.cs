using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.Model
{
    public class Cryptocurr
    {
        public Cryptocurr(string id, int rank, string currency, string digest, double price, double change, double volume, double marketCapUsd)
        {
            Id = id;
            Rank = rank;
            Currency = currency;
            Digest = digest;
            Price = price;
            Change = change;
            Volume = volume;
            MarketCapUsd = marketCapUsd;
        }

        public string Id { get; set; }

        public int Rank { get; set; }

        public string Currency { get; set; }

        public string Digest { get; set; }

        public double Price { get; set; }

        public double Change { get; set; }

        public double Volume { get; set; }

        public double MarketCapUsd { get; set; }
    }
}
