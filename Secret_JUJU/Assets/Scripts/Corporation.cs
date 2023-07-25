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
            float marketPrice = float.Parse(item.mkp);
            float closingPrice = float.Parse(item.clpr);
            float highPrice = float.Parse(item.hipr);
            float lowPrice = float.Parse(item.lopr);
            stockData.Add(new StockData(versus, marketPrice, closingPrice, highPrice, lowPrice));
        }
    }
}
