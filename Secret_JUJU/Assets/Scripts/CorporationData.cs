using System.Collections.Generic;

public class CorporationData
{
    public string BaseDate { get; private set; }             // ���� ����
    public string ShortenCode { get; private set; }          // ���� �ڵ�
    public string ISINCode { get; private set; }             // ISIN �ڵ�
    public string ItemName { get; private set; }             // �����
    public string MarketCategory { get; private set; }       // ���屸��
    public string ClosingPrice { get; private set; }         // ����
    public string Versus { get; private set; }               // ���
    public string FloatingRate { get; private set; }         // �����
    public string MarketPrice { get; private set; }          // �ð�
    public string HighPrice { get; private set; }            // ��
    public string LowPrice { get; private set; }             // ����
    public string TradeQuantity { get; private set; }        // �ŷ���
    public string TradePrice { get; private set; }           // �ŷ����
    public string ListingStockCount { get; private set; }    // �����ֽļ�
    public string MarketTotalAmounts { get; private set; }	 // �ð��Ѿ�
}
