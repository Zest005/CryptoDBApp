using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CryptoDBApp.Model
{
    public class DataWorker
    {
        public void MyTestRequest()
        {
            var request = new GetRequest("https://api.coincap.io/v2/assets");
            request.Run();
        }
        // заполнить список Cryptocurr данными из API

        // выбрать top 10 по RANK и заполнить список CryptoCurrTop

        // 
    }
}
