using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public enum CorporationID : int { A = 0, B, C, D, E, F }

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
    }
}
