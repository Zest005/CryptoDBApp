using System;
using System.IO;
using System.Net;

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
