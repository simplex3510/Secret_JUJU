using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public int TurnMax { get; private set; }
        public int TurnIndex { get; private set; }
        public int CoinAmount { get; private set; }
        public int StockAmount { get; private set; }
        public float cumulativeProfitRate { get; private set; }

        private Corporations market;

        private int investAmount;
        private int curStockPrice;

        public void InitializeGame()
        {
            market = MarketManager.Instance.market;
            TurnMax = MarketManager.Instance.StockCount;
            TurnIndex = -1;
            StockAmount = 0;
            CoinAmount = Random.Range(market.corporations[0].corporation[0].LowPrice,
                                      market.corporations[0].corporation[0].HighPrice);
        }

        public void MoveTurn()
        {
            if (TurnIndex < TurnMax)
            {
                TurnIndex++;
            }

            CheckProfitRate();
            CheckGameState();
        }

        public void BuyStock()
        {
            
        }

        public void SellStock()
        {
            if (StockAmount == 0)
            {
                return;
            }

        }

        public StockData currentStockData()
        {
            return market.corporations[(int)CorporationID.A].corporation[TurnIndex];
        }

        private float totalProfitRate;
        private void CheckProfitRate()
        {
            /*Calculate ProfitRate*/
        }

        private void CheckGameState()
        {
            /*Check Conditions*/
        }
    }
}