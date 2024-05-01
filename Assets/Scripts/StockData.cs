using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class StockData
{

    public float Versus { get { return versus; } private set { versus = value; } }
    private float versus;          // 대비
    public int MarketPrice { get { return marketPrice; } private set { marketPrice = value; } }
    private int marketPrice;     // 시가
    public int ClosingPrice { get { return closingPrice; } private set { closingPrice = value; } }
    private int closingPrice;    // 종가
    public int HighPrice { get { return highPrice; } private set { highPrice = value; } }
    private int highPrice;       // 고가
    public int LowPrice { get { return lowPrice; } private set { lowPrice = value; } }             
    private int lowPrice;        // 저가

    public StockData(float versus, int marketPrice, int closingPrice, int highPrice, int lowPrice)
    {
        this.versus = versus;
        this.marketPrice = marketPrice;
        this.closingPrice = closingPrice;
        this.highPrice = highPrice;
        this.lowPrice = lowPrice;
    }
}
