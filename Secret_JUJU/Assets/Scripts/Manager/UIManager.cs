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
            UpdateStockChart();

            UpdateTurnUI();
            UpdateAccountUI();
            UpdateSlideUI();

            MoveTurn += GameManager.Instance.MoveTurn;
            MoveTurn += UpdateStockChart;
            MoveTurn += UpdateTurnUI;
            MoveTurn += UpdateAccountUI;
            MoveTurn += UpdateSlideUI;
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
        #endregion

        // Turn UI
        #region Turn UI
        [SerializeField] private TextMeshProUGUI turnText;

        public void UpdateTurnUI()
        {
            turnText.text = $"({GameManager.Instance.TurnIndex + 1}/{GameManager.Instance.TurnMax})";
        }

        #endregion

        // Account UI
        #region Account UI
        [SerializeField] private TextMeshProUGUI coinAmountText;
        [SerializeField] private TextMeshProUGUI stockAmountText;
        [SerializeField] private TextMeshProUGUI profitRateText;

        public void UpdateAccountUI()
        {
            coinAmountText.text = $"{GameManager.Instance.CoinAmount}";
            stockAmountText.text = $"{GameManager.Instance.StockAmount}";
            profitRateText.text = $"({GameManager.Instance.cumulativeProfitRate}%)";
        }
        #endregion

        // Slide UI
        #region Slide UI
        [SerializeField] private TextMeshProUGUI slide_CoinText;
        [SerializeField] private TextMeshProUGUI slide_StockText;

        public void OnClickBuyStock()
        {
            GameManager.Instance.BuyStock();
            UpdateAccountUI();
        }

        public void OnClickSellStock()
        {
            GameManager.Instance.SellStock();
            UpdateAccountUI();
        }

        public void OnClickUpCoin()
        {
            GameManager.Instance.UpCoin();
            UpdateSlideUI();
        }

        public void OnClickDownCoin()
        {
            GameManager.Instance.DownCoin();
            UpdateSlideUI();
        }

        public void OnClickUpStock()
        {
            GameManager.Instance.UpStock();
            UpdateSlideUI();
        }

        public void OnClickDownStock()
        {
            GameManager.Instance.DownStock();
            UpdateSlideUI();
        }

        private void UpdateSlideUI()
        {
            slide_CoinText.text = $"{GameManager.Instance.Slide_Coin}";
            slide_StockText.text = $"{GameManager.Instance.Slide_Stock}";
        }
        #endregion
    }
}