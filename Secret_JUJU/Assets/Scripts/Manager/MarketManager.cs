using System.Collections;
using System.Collections.Generic;
using UnityEngine;

namespace Manager
{
    public class MarketManager : Singleton<MarketManager>
    {
        public Corporations Market;

        private static readonly int MAX_CORPORATION_COUNT = 6;

        public void InitializeMarket()
        {
            Market = new Corporations(MAX_CORPORATION_COUNT);
        }


    }
}
