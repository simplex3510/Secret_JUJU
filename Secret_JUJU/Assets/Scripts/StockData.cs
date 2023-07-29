using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class StockData
{

    public float Versus { get { return versus; } private set { versus = value; } }
    private float versus;          // 대비
    public float MarketPrice { get { return marketPrice; } private set { marketPrice = value; } }
    private float marketPrice;     // 시가
    public float ClosingPrice { get { return closingPrice; } private set { closingPrice = value; } }
    private float closingPrice;    // 종가
    public float HighPrice { get { return highPrice; } private set { highPrice = value; } }
    private float highPrice;       // 고가
    public float LowPrice { get { return lowPrice; } private set { lowPrice = value; } }             
    private float lowPrice;        // 저가

    public StockData(float versus, float marketPrice, float closingPrice, float highPrice, float lowPrice)
    {
        this.versus = versus;
        this.marketPrice = marketPrice;
        this.closingPrice = closingPrice;
        this.highPrice = highPrice;
        this.lowPrice = lowPrice;
    }
}
