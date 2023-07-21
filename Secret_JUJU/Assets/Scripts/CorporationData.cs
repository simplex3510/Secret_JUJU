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
    public string BaseDate { get; set; }             // ���� ����
    public string shortenCode { get; set; }          // ���� �ڵ�
    public string ISINCode { get; set; }             // ISIN �ڵ�
    public string ItemName { get; set; }             // �����
    public string MarketCategory { get; set; }       // ���屸��
    public string ClosingPrice { get; set; }         // ����
    public string Versus { get; set; }               // ���
    public string FloatingRate { get; set; }         // �����
    public string MarketPrice { get; set; }          // �ð�
    public string HighPrice { get; set; }            // ��
    public string LowPrice { get; set; }             // ����
    public string TradeQuantity { get; set; }        // �ŷ���
    public string TradePrice { get; set; }           // �ŷ����
    public string ListingStockCount { get; set; }    // �����ֽļ�
    public string MarketTotalAmounts { get; set; }	 // �ð��Ѿ�
}
