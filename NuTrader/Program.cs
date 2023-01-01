using System.Xml;
using System.Text.Json;
using NuTrader;


Console.WriteLine("---Start NuTrader\n");

//var marketsJson = GetAllMarkets();
//var markets = JsonSerializer.Deserialize<PredictItMarkets>(marketsJson);
//Console.WriteLine(markets);
//Console.WriteLine($"\n{markets.Count()} MARKETS\n");

CsvFile csv;

// https://fred.stlouisfed.org/series/THREEFF2
csv = CsvFile.LoadCsv(@"/Users/michael/Git/mdhatmaker/NuTrader/data/THREEFF2.csv", 1);
var ff2 = GetStLouisFedValues(csv);

// https://fred.stlouisfed.org/series/T10Y2Y
csv = CsvFile.LoadCsv(@"/Users/michael/Git/mdhatmaker/NuTrader/data/T10Y2Y.csv", 1);
var t10y2 = GetStLouisFedValues(csv);

// https://fred.stlouisfed.org/series/DGS2#
csv = CsvFile.LoadCsv(@"/Users/michael/Git/mdhatmaker/NuTrader/data/DGS2.csv", 1);
var dgs2 = GetStLouisFedValues(csv);

// https://fred.stlouisfed.org/series/DGS10#
csv = CsvFile.LoadCsv(@"/Users/michael/Git/mdhatmaker/NuTrader/data/DGS10.csv", 1);
var dgs10 = GetStLouisFedValues(csv);

// https://fred.stlouisfed.org/docs/api/fred/


Console.WriteLine("\n---End NuTrader");


/*
Parse string containing date and Decimal value
*/
Dictionary<DateTime, Decimal> GetStLouisFedValues(CsvFile csv)
{
    Dictionary<DateTime, Decimal> values = new();
    foreach (var line in csv.Lines)
    {
        var split = line.Split(',');
        if (split[1] != ".")    // Ignore if value is "."
        {
            values[DateTime.Parse(split[0])] = Decimal.Parse(split[1]);
        }
    }

    return values;
}

/*
If you wish to receive data for all markets on the site, the format for the API URL is:
https://www.predictit.org/api/marketdata/all/
*/
string GetAllMarkets()
{
    HttpClient client = new HttpClient();

    // Send CaseNumber as Key Value to Post method
    //var values = new Dictionary<string, string> { { "appReceiptNum", CaseNumber } };
    //var content = new FormUrlEncodedContent(values);
    string url = "https://www.predictit.org/api/marketdata/all/";

    // Make a post call using HttpClient to Web with url and content
    //var response = client.PostAsync(url, content).Result;
    var response = client.GetAsync(url).Result;
    var responseJson= response.Content.ReadAsStringAsync().Result;

    // Create a HTML Document to parse and read html tags
    //var htmlDocument = new HtmlDocument();
    //htmlDocument.LoadHtml(html);

    //SelectNodes method will retrievs all html elements specified (h1)
    //var caseStatus = htmlDocument.DocumentNode.SelectNodes("h1").FirstOrDefault();

    //return caseStatus.InnerText;
    return responseJson;
}

/*
If you wish to receive data for a specific market, the format for the API URL is:
https://www.predictit.org/api/marketdata/markets/[ID]
*/
string GetMarket(int marketId)
{
    HttpClient client = new HttpClient();

    string url = $"https://www.predictit.org/api/marketdata/markets/{marketId}";

    // Make a post call using HttpClient to Web with url and content
    var response = client.GetAsync(url).Result;
    var responseMessage = response.Content.ReadAsStringAsync().Result;

    return responseMessage;
}
