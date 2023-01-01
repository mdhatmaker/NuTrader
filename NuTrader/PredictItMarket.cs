using System;
using System.Text;

namespace NuTrader
{
    public class PredictItMarkets
    {
        public List<PredictItMarket> markets { get; set; }

        public int Count()
        {
            return markets.Count;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder();

            foreach (var m in markets)
            {
                sb.Append($"{m}\n");
            }
            return sb.ToString();
        }
    }


    public class PredictItMarket
    {
        public int id { get; set; }                                 //7673,
        public string name { get; set; }                            //"How many tie-breaking Senate votes will Kamala Harris cast in 2022?",
        public string shortName { get; set; }                       //"Harris tie-breakers in 2022?",
        public string image { get; set; }                           //"https://az620379.vo.msecnd.net/images/Markets/42e624ca-be5f-4c3e-8939-86bb42b0314d.jpg",
        public string url { get; set; }                             //"https://www.predictit.org/markets/detail/7673/How-many-tie-breaking-Senate-votes-will-Kamala-Harris-cast-in-2022",
        public List<PredictItContract> contracts { get; set; }
        public DateTime timeStamp { get; set; }                     //"2022-09-27T21:33:25.8861752",
        public string status { get; set; }                          //"Open"

        public PredictItMarket()
		{
		}

        public override string ToString()
        {
            return $"{id} {timeStamp} {status} {shortName}  {contracts.Count} CONTRACTS  '{name}'";
        }
    }
}

