namespace CryptoDBApp.Model
{
    public class CryptocurrShortList
    {
        // For Top10 List
        public CryptocurrShortList(string id, int rank, string currency, string digest, double price, double marketCap)
        {
            Id = id;
            Rank = rank;
            Currency = currency;
            Digest = digest;
            Price = price;
            MarketCap = marketCap;
        }

        public string Id { get; set; }

        public int Rank { get; set; }

        public string Currency { get; set; }

        public string Digest { get; set; }

        public double Price { get; set; }

        public double MarketCap { get; set; }
    }
}
