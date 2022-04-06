using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Http;
using System.Text;

namespace CoinMarketCapGetCurrency
{
    internal class Program
    {
        const string USER = "";
        const string YOURAPIKEY = "";
        const string URL = "https://pro-api.coinmarketcap.com/v1/global-metrics/quotes/latest";
        const string PARAMETERS = "?CMC_PRO_API_KEY=" + YOURAPIKEY;

        static void Main(string[] args)
        {

            // GetMethod();
           
            // this one is the best according to COINMARKETCAP documentatio api. 
            //GetWithHeaderMethod();
        }
        static void GetWithHeaderMethod()
        {
            //Needed ->  "X-CMC_PRO_API_KEY": YOURAPIKEY

            using (var client = new HttpClient())
            {
                var endpoint = new Uri(URL);
                client.DefaultRequestHeaders.Add("X-CMC_PRO_API_KEY", YOURAPIKEY);
                client.DefaultRequestHeaders.Add("Accept", "application/json");

                var result = client.GetAsync(endpoint).Result;
                var json = result.Content.ReadAsStringAsync().Result;
                Console.WriteLine(json);
                WriteOnFIle(json);
            }
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

            if (File.Exists(string.Format($@"C:\Users\{USER}\Documents\CoinMarketCapCurrency.json")))
            {
                File.Delete(string.Format($@"C:\Users\{USER}\Documents\CoinMarketCapCurrency.json"));
            }

            File.WriteAllText(string.Format($@"C:\Users\{USER}\Documents\CoinMarketCapCurrency.json"), Json.ToString());

        }
    }
}
