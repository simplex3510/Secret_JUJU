using System.Collections.Generic;

public class CorporationData
{
    public string BaseDate { get; private set; }             // 기준 일자
    public string ShortenCode { get; private set; }          // 단축 코드
    public string ISINCode { get; private set; }             // ISIN 코드
    public string ItemName { get; private set; }             // 종목명
    public string MarketCategory { get; private set; }       // 시장구분
    public string ClosingPrice { get; private set; }         // 종가
    public string Versus { get; private set; }               // 대비
    public string FloatingRate { get; private set; }         // 등락률
    public string MarketPrice { get; private set; }          // 시가
    public string HighPrice { get; private set; }            // 고가
    public string LowPrice { get; private set; }             // 저가
    public string TradeQuantity { get; private set; }        // 거래량
    public string TradePrice { get; private set; }           // 거래대금
    public string ListingStockCount { get; private set; }    // 상장주식수
    public string MarketTotalAmounts { get; private set; }	 // 시가총액
}
