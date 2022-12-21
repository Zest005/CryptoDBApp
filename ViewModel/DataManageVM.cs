using CryptoDBApp.Model;
using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.ViewModel
{
    public class DataManageVM
    {
        public List<Cryptocurr> Cryptocurrencies = new List<Cryptocurr>();

        public void GetAllCurrsToList()
        {
            var request = new GetRequest("https://api.coincap.io/v2/assets");
            request.Run();

            var response = request.Response;

            var json = JObject.Parse(response);
            var data = json["data"];

            foreach (var item in data)
            {
                Cryptocurrencies.Add(DataWorker.GetCurrency(item["id"].ToString(), (int)item["rank"], item["name"].ToString(), item["symbol"].ToString(),
                    (double)item["price"], (double)item["changePercent24Hr"], (double)item["volumeUsd24Hr"], (double)item["marketCapUsd"]));
            }
        }

        public void 
    }
}
