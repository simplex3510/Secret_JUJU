using System.Collections.Generic;

[System.Serializable]
public class Corporations
{
    public List<Corporation> corporations;
}

[System.Serializable]
public class Corporation
{
    public List<CorporationData> corporationInfoes;
}

[System.Serializable]
public class CorporationData
{
    public string BaseDate { get; set; }             // 기준 일자
    public string shortenCode { get; set; }          // 단축 코드
    public string ISINCode { get; set; }             // ISIN 코드
    public string ItemName { get; set; }             // 종목명
    public string MarketCategory { get; set; }       // 시장구분
    public string ClosingPrice { get; set; }         // 종가
    public string Versus { get; set; }               // 대비
    public string FloatingRate { get; set; }         // 등락률
    public string MarketPrice { get; set; }          // 시가
    public string HighPrice { get; set; }            // 고가
    public string LowPrice { get; set; }             // 저가
    public string TradeQuantity { get; set; }        // 거래량
    public string TradePrice { get; set; }           // 거래대금
    public string ListingStockCount { get; set; }    // 상장주식수
    public string MarketTotalAmounts { get; set; }	 // 시가총액
}
