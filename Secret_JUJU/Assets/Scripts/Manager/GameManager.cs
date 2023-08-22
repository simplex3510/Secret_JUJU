using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    public class GameManager : Singleton<GameManager>
    {
        public int TurnMax { get; private set; }
        public int TurnIndex { get; private set; }
        public int CoinAmount { get; private set; }
        public int StockAmount { get; private set; }
        public int unitPrice { get; private set; }
        public float cumulativeProfitRate { get; private set; }

        public int Slide_Coin { get; private set; }
        public int Slide_Stock { get; private set; }

        private Corporations market;

        // Main Logic
        #region Main Logic
        public void InitializeGame()
        {
            market = MarketManager.Instance.market;
            TurnMax = MarketManager.Instance.StockCount;
            TurnIndex = 0;
            StockAmount = 0;
            CoinAmount = Random.Range(CurrentStockData().LowPrice, CurrentStockData().HighPrice);
            cumulativeProfitRate = 0f;
            Slide_Coin = 0;
            Slide_Stock = 0;

            InitializeUnit(CurrentStockData().MarketPrice);
            InitializeSlide();
        }

        public StockData CurrentStockData() => market.corporations[(int)CorporationID.A].corporation[TurnIndex];

        public void MoveTurn()
        {
            if (TurnIndex < TurnMax)
            {
                TurnIndex++;
            }

            InitializeSlide();
            CheckBuy();
            CheckSell();
            CheckProfitRate();
            CheckGameState();
        }

        private void InitializeUnit(int marketPrice)
        {
            if (500_000 < marketPrice)
            {
                unitPrice = 1000;
            }
            else if (200_000 < marketPrice)
            {
                unitPrice = 500;
            }
            else if (50_000 < marketPrice)
            {
                unitPrice = 100;
            }
            else if (20_000 < marketPrice)
            {
                unitPrice = 50;
            }
            else if (5_000 < marketPrice)
            {
                unitPrice = 10;
            }
            else if (2_000 < marketPrice)
            {
                unitPrice = 5;
            }
            else
            {
                unitPrice = 1;
            }
        }
        #endregion

        // Buy & Sell Logic
        #region Buy & Sell Logic
        private int investedCoin;
        private int investedStock;
        private bool hasInvest;

        public void BuyStock()
        {
            int totalPrice = Slide_Coin * Slide_Stock;
            if (CoinAmount < totalPrice)
            {
                return;
            }

            hasInvest = true;

            investedCoin = totalPrice;

            CoinAmount -= totalPrice;
            StockAmount += Slide_Stock;
        }

        public void SellStock()
        {

        }

        private void CheckBuy()
        {
            if (hasInvest == false)
            {
                return;
            }
        }

        private void CheckSell()
        {
            if (hasInvest == false)
            {
                return;
            }
        }
        #endregion

        // ProfitRate Logic
        #region ProfitRate Logic
        private int investAmount;
        private int curStockPrice;
        private float totalProfitRate;

        private void CheckProfitRate()
        {
            /*Calculate ProfitRate*/
        }

        private void CheckGameState()
        {
            /*Check Conditions*/
        }
    #endregion

        // Slide Object Logic
        #region Slide Object Logic
        public void InitializeSlide()
        {
            Slide_Coin = CurrentStockData().MarketPrice;
            Slide_Stock = 0;
        }

        public void UpCoin()
        {
            Slide_Coin += unitPrice;
        }

        public void DownCoin()
        {
            if (0 < Slide_Coin)
            {
                Slide_Coin -= unitPrice;
            }
        }

        public void UpStock()
        {
            Slide_Stock += 1;
        }

        public void DownStock()
        {
            if (0 < Slide_Stock)
            {
                Slide_Stock -= 1;
            }
        }
        #endregion
    }
}