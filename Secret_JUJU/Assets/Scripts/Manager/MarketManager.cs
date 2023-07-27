using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class MarketManager : Singleton<MarketManager>
    {
        public Corporations market;        
        public int StockCount { get; private set; }

        private static readonly int MAX_CORPORATION_COUNT = 6;

        
        public void InitializeMarket()
        {
            StockCount = JsonManager.Instance.JsonData.response.body.totalCount;
            market = new Corporations(MAX_CORPORATION_COUNT);
        }

        public void ShowMarket()
        {
            foreach (var corporation in market.corporations)
            {
                UIManager.Instance.ShowStockChart(corporation);
            }
        }
    }
}
