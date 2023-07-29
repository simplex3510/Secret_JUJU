using Manager;
using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[Serializable]
public class Corporation
{
    //public List<CorporationData> corporationData = new List<CorporationData>(JsonManager.Instance.JsonData.response.body.items.item.Count);
    public List<StockData> stockData;

    public Corporation()
    {
        stockData = new List<StockData>(JsonManager.Instance.JsonData.response.body.items.item.Count);

        foreach (var item in JsonManager.Instance.JsonData.response.body.items.item)
        {
            float versus = float.Parse(item.vs);
            int marketPrice = int.Parse(item.mkp);
            int closingPrice = int.Parse(item.clpr);
            int highPrice = int.Parse(item.hipr);
            int lowPrice = int.Parse(item.lopr);
            stockData.Add(new StockData(versus, marketPrice, closingPrice, highPrice, lowPrice));
        }
    }
}
