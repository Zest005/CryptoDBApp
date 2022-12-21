using Newtonsoft.Json.Linq;
using System.Text.Json;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;

namespace CryptoDBApp.Model
{
    public static class DataWorker
    {
        // all currs
        public static CryptocurrFullList GetFullCurrency(string id, int rank, string currency, string digest, double price, double change, double volume, double marketCap)
        {
            return new CryptocurrFullList(id, rank, currency, digest, price, change, volume, marketCap);
        }

        public static List<CryptocurrFullList> GetFullList()
        {
            List<CryptocurrFullList> FullCryptocurrencies = new List<CryptocurrFullList>();

            var request = new GetRequest("https://api.coincap.io/v2/assets");
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var data = json["data"];

            var tempList = new List<CryptocurrFullList>();
            foreach (var item in data)
            {
                string id = (item["id"].ToObject<string>()).ToString();
                int rank = (int)item["rank"].ToObject<int>();
                string name = (item["name"].ToObject<string>()).ToString();
                string symbol = (item["symbol"].ToObject<string>()).ToString();
                double price = (double)item["priceUsd"].ToObject<double>();
                double changePercent24Hr = (double)item["changePercent24Hr"].ToObject<double>();
                double volumeUsd24Hr = (double)item["volumeUsd24Hr"].ToObject<double>();
                double marketCapUsd = (double)item["marketCapUsd"].ToObject<double>();

                FullCryptocurrencies.Add(DataWorker.GetFullCurrency(id, rank, name, symbol, price, changePercent24Hr, volumeUsd24Hr, marketCapUsd));
            }

            return FullCryptocurrencies;
        }

        // top10
        public static CryptocurrShortList GetShortCurrency(string id, int rank, string currency, string digest, double price, double marketCap)
        {
            return new CryptocurrShortList(id, rank, currency, digest, price, marketCap);
        }

        public static List<CryptocurrShortList> GetShortList()
        {
            List<CryptocurrShortList> ShortCryptocurrencies = new List<CryptocurrShortList>();

            var request = new GetRequest("https://api.coincap.io/v2/assets");
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var data = json["data"];
            int checker = 1;

            foreach (var item in data)
            {
                if (checker > 10)
                {
                    break;
                }

                string id = (item["id"].ToObject<string>()).ToString();
                int rank = (int)item["rank"].ToObject<int>();
                string name = (item["name"].ToObject<string>()).ToString();
                string symbol = (item["symbol"].ToObject<string>()).ToString();
                double price = (double)item["priceUsd"].ToObject<double>();
                double marketCapUsd = (double)item["marketCapUsd"].ToObject<double>();

                ShortCryptocurrencies.Add(DataWorker.GetShortCurrency(id, rank, name, symbol, price, marketCapUsd));

                checker++;
            }

            return ShortCryptocurrencies;
        }
    }
}
