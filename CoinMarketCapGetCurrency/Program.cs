using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace CoinMarketCapGetCurrency
{
    internal class Program
    {
        const string usuario = "aluno06.TSACBRRJLP046";
        const string YOURAPIKEY = "13e2a7d3-2fc0-4240-a460-b0ddb0a9d1d4";
        const string URL = "https://pro-api.coinmarketcap.com/v1/global-metrics/quotes/latest";
        const string PARAMETERS = "?CMC_PRO_API_KEY=" + YOURAPIKEY;
        static void Main(string[] args)
        {
            // GetMethod();
            PostMethod();
        }
        static void PostMethod()
        {
            //Needed ->  "X-CMC_PRO_API_KEY": API_KEY
        }
        static void GetMethod()
        {
            using (var client = new HttpClient())
            {
                var endpoint = new Uri(URL + PARAMETERS);
                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                WriteOnFIle(json);

            }
        }
        static void WriteOnFIle(String Json)
        {

            if (File.Exists(string.Format($@"C:\Users\{usuario}\Documents\CoinMarketCapCurrency.json")))
            {
                File.Delete(string.Format($@"C:\Users\{usuario}\Documents\CoinMarketCapCurrency.json"));
            }

            File.WriteAllText(string.Format($@"C:\Users\{usuario}\Documents\CoinMarketCapCurrency.json"), Json.ToString());

        }
    }
}
