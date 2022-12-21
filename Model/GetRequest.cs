using CryptoDBApp.Model;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

//var request = new GetRequest("https://api.coincap.io/v2/assets");
//request.Run();

namespace CryptoDBApp.Model
{
    public class GetRequest
    {
        HttpWebRequest Request;

        string Address;

        public GetRequest(string address)
        {
            Address = address;
        }

        public string Response { get; set; }

        public void Run()
        {
            Request = (HttpWebRequest)WebRequest.Create(Address);
            Request.Method = "Get";

            try
            {
                HttpWebResponse response = (HttpWebResponse)Request.GetResponse();
                var stream = response.GetResponseStream();

                if (stream != null)
                    Response = new StreamReader(stream).ReadToEnd();
            }
            catch (Exception) { }
        }
    }
}
