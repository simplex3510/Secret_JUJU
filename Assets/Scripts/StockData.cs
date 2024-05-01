using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class StockData
{

    public float Versus { get { return versus; } private set { versus = value; } }
    private float versus;          // ���
    public int MarketPrice { get { return marketPrice; } private set { marketPrice = value; } }
    private int marketPrice;     // �ð�
    public int ClosingPrice { get { return closingPrice; } private set { closingPrice = value; } }
    private int closingPrice;    // ����
    public int HighPrice { get { return highPrice; } private set { highPrice = value; } }
    private int highPrice;       // ��
    public int LowPrice { get { return lowPrice; } private set { lowPrice = value; } }             
    private int lowPrice;        // ����

    public StockData(float versus, int marketPrice, int closingPrice, int highPrice, int lowPrice)
    {
        this.versus = versus;
        this.marketPrice = marketPrice;
        this.closingPrice = closingPrice;
        this.highPrice = highPrice;
        this.lowPrice = lowPrice;
    }
}
