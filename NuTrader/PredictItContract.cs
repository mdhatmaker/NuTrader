using System;
namespace NuTrader
{
	public class PredictItContract
    {
        public int id { get; set; }                     //28901,
        public string dateEnd { get; set; }             //"2022-12-31T23:59:00",
        public string image { get; set; }               //"https://az620379.vo.msecnd.net/images/Contracts/small_42e624ca-be5f-4c3e-8939-86bb42b0314d.jpg",
        public string name { get; set; }                //"3 or fewer votes",
        public string shortName { get; set; }           //"3 or fewer",
        public string status { get; set; }              //"Open",
        public decimal? lastTradePrice { get; set; }    //0.01,
        public decimal? bestBuyYesCost { get; set; }    //0.01,
        public decimal? bestBuyNoCost { get; set; }     //null,
        public decimal? bestSellYesCost { get; set; }   //null,
        public decimal? bestSellNoCost { get; set; }    //0.99,
        public decimal? lastClosePrice { get; set; }    //0.01,
        public int displayOrder { get; set; }           //0


        public PredictItContract()
		{
		}

        public override string ToString()
        {
            return $"{id} {dateEnd} {shortName} {status}  '{name}'  LAST_CLOSE {lastClosePrice}  LAST_TRADE {lastTradePrice}  YES {bestBuyYesCost}:{bestSellYesCost}  NO {bestBuyNoCost}:{bestSellNoCost}";
        }
    }
}

