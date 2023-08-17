using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

namespace Manager
{
    public partial class UIManager : Singleton<UIManager>
    {
        public delegate void MoveTurnDelegate();
        public MoveTurnDelegate MoveTurn;

        public void OnClickMoveTurn() => MoveTurn();

        public void InitializeUI()
        {
            InitializeStockChart();
            InitializeInterface();

            MoveTurn += GameManager.Instance.MoveTurn;
            MoveTurn += UpdateInterface;
            MoveTurn += UpdateStockChart;
            MoveTurn += InitializeCoinSlide;
            MoveTurn += InitializeStockSlide;
        }

        // Stock Graph UI
        #region Stock Chart
        public float AxisMaxY { get; private set; } = int.MinValue;
        public float AxisMinY { get; private set; } = int.MaxValue;
        public float AxisMaxX { get; private set; } = 0;
        public readonly float CORRECTION_VALUE = 0.1f;

        [SerializeField] private RectTransform chartContainer;
        [SerializeField] private GameObject stockPrefab;

        private readonly int CHART_HEIGHT = 950;
        private readonly int CHART_WIDTH = 530;
        private readonly int OFFSET_X = 50;

        private List<StockObject> stockObjects;

        public void InitializeStockChart()
        {
            stockObjects = new List<StockObject>();

            for (int i = 0; i < chartContainer.childCount; i++)
            {
                Destroy(chartContainer.GetChild(i).gameObject);
            }
        }

        public void UpdateStockChart()
        {
            int turnIndex = GameManager.Instance.TurnIndex;

            UpdateAxisMaxY(MarketManager.Instance.market.corporations[(int)CorporationID.A].corporation[turnIndex].HighPrice);
            UpdateAxisMinY(MarketManager.Instance.market.corporations[(int)CorporationID.A].corporation[turnIndex].LowPrice);

            float xVector = OFFSET_X * turnIndex;
            float yVector = AxisMaxY;
            Vector2 stockMaxVector = new Vector2(xVector, yVector);

            AxisMaxX = OFFSET_X * (turnIndex + 1);
            chartContainer.sizeDelta = new Vector2(AxisMaxX, (AxisMaxY - AxisMinY) * CORRECTION_VALUE);

            SetPositionStockObjects(turnIndex);

            StockObject newStockObject = CreateNewStockObject(turnIndex, stockMaxVector);
            stockObjects.Add(newStockObject);
        }

        public StockObject CreateNewStockObject(int count, Vector2 stockMaxVector)
        {
            StockObject stockObject = Instantiate(stockPrefab, chartContainer.transform, false).GetComponent<StockObject>();
            StockData stockData = MarketManager.Instance.market.corporations[(int)CorporationID.A].corporation[count];

            stockObject.InitializeStock(stockData, stockMaxVector);

            return stockObject;
        }

        private void SetPositionStockObjects(int turnIndex)
        {
            for (int stockIndex = 0; stockIndex < turnIndex && turnIndex < GameManager.Instance.TurnMax; stockIndex++)
            {
                stockObjects[stockIndex].rectTransform.anchoredPosition = new Vector2(stockIndex * OFFSET_X, (stockObjects[stockIndex].stockData.LowPrice - AxisMinY) *CORRECTION_VALUE);
            }
        }

        private void UpdateAxisMaxY(int highPrice)
        {

            if (AxisMaxY < highPrice)
            {
                AxisMaxY = highPrice;
            }
        }

        private void UpdateAxisMinY(int lowPrice)
        {
            if (lowPrice < AxisMinY)
            {
                AxisMinY = lowPrice;
            }
        }

        //private void UpdateUnitY(int marketPrice)
        //{
        //    if (500_000 < marketPrice)
        //    {
        //        unitY = 1000;
        //    }
        //    else if (200_000 < marketPrice)
        //    {
        //        unitY = 500;
        //    }
        //    else if (50_000 < marketPrice)
        //    {
        //        unitY = 100;
        //    }
        //    else if (20_000 < marketPrice)
        //    {
        //        unitY = 50;
        //    }
        //    else if (5_000 < marketPrice)
        //    {
        //        unitY = 10;
        //    }
        //    else if (2_000 < marketPrice)
        //    {
        //        unitY = 5;
        //    }
        //    else
        //    {
        //        unitY = 1;
        //    }
        //}
        #endregion

        #region Interface
        [SerializeField] private TextMeshProUGUI coinAmountText;
        [SerializeField] private TextMeshProUGUI stockAmountText;
        [SerializeField] private TextMeshProUGUI profitRateText;
        [SerializeField] private TextMeshProUGUI turnText;

        public void InitializeInterface()
        {
            coinAmountText.text = $"{GameManager.Instance.CoinAmount}";
            stockAmountText.text = $"{GameManager.Instance.StockAmount}";
            profitRateText.text = $"({GameManager.Instance.cumulativeProfitRate}%)";
            turnText.text = $"({GameManager.Instance.TurnIndex + 1}/{GameManager.Instance.TurnMax})";
        }

        public void UpdateInterface()
        {
            turnText.text = $"({GameManager.Instance.TurnIndex + 1}/{GameManager.Instance.TurnMax})";
        }
        #endregion

        #region Slide Interface
        [SerializeField] private TextMeshProUGUI coinSlide_CoinText;
        [SerializeField] private TextMeshProUGUI coinSlide_StockText;
        private int coinSlide_Coin;
        private int coinSlide_Stock;
        
        [SerializeField] private TextMeshProUGUI stockSlide_CoinText;
        [SerializeField] private TextMeshProUGUI stockSlide_StockText;
        private int stockSlide_Coin;
        private int stockSlide_Stock;

        private void InitializeCoinSlide()
        {
            coinSlide_Coin = GameManager.Instance.currentStockData().MarketPrice;
            coinSlide_Stock = 0;

            coinSlide_CoinText.text = $"{coinSlide_Coin}";
            coinSlide_StockText.text = $"{coinSlide_Stock}";

        }

        private void InitializeStockSlide()
        {
            stockSlide_Coin = GameManager.Instance.currentStockData().MarketPrice;
            stockSlide_Stock = 0;
            
            stockSlide_CoinText.text = $"{stockSlide_Coin}";
            stockSlide_StockText.text = $"{stockSlide_Stock}";
        }

        private void PlusBuyStockPrice()
        {

        }

        private void MinusBuyStockPrice()
        {

        }

        private void PlusBuyStock()
        {

        }

        private void MinusBuyStock()
        {

        }
        #endregion
    }
}