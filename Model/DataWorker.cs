using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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

            foreach (var item in data)
            {
                FullCryptocurrencies.Add(DataWorker.GetFullCurrency(item["id"].ToString(),
                                                                    (int)item["rank"],
                                                                    item["name"].ToString(),
                                                                    item["symbol"].ToString(),
                                                                    (double)item["price"],
                                                                    (double)item["changePercent24Hr"],
                                                                    (double)item["volumeUsd24Hr"],
                                                                    (double)item["marketCapUsd"]));
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

            foreach (var item in data)
            {
                ShortCryptocurrencies.Add(DataWorker.GetShortCurrency(item["id"].ToString(),
                                                                      (int)item["rank"],
                                                                      item["name"].ToString(),
                                                                      item["symbol"].ToString(),
                                                                      (double)item["price"],
                                                                      (double)item["marketCapUsd"]));
            }

            return ShortCryptocurrencies;
        }
    }
}
