using System;
using System.Collections;
using System.Collections.Generic;

[Serializable]
public class StockData
{

    public float Versus { get { return versus; } private set { versus = value; } }
    private float versus;          // ���
    public float MarketPrice { get { return marketPrice; } private set { marketPrice = value; } }
    private float marketPrice;     // �ð�
    public float ClosingPrice { get { return closingPrice; } private set { closingPrice = value; } }
    private float closingPrice;    // ����
    public float HighPrice { get { return highPrice; } private set { highPrice = value; } }
    private float highPrice;       // ��
    public float LowPrice { get { return lowPrice; } private set { lowPrice = value; } }             
    private float lowPrice;        // ����

    public StockData(float versus, float marketPrice, float closingPrice, float highPrice, float lowPrice)
    {
        this.versus = versus;
        this.marketPrice = marketPrice;
        this.closingPrice = closingPrice;
        this.highPrice = highPrice;
        this.lowPrice = lowPrice;
    }
}
