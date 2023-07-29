using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    // Stock Graph UI
    public partial class UIManager : Singleton<UIManager>
    {
        public float MaxY { get; private set; } = 0;
        public float GraphHeight { get; private set; }

        [SerializeField] private RectTransform graphContainer;
        [SerializeField] private GameObject stockPrefab;

        private void Awake()
        {
            GraphHeight = graphContainer.sizeDelta.y;
        }

        public void CreateStockObject(Corporation corporation, int count, Vector2 stockPosition)
        {
            StockObject stockObject = Instantiate(stockPrefab, graphContainer.transform, false).GetComponent<StockObject>();
            StockData stockData = corporation.stockData[count];

            if (MaxY < stockData.HighPrice - stockData.LowPrice)
            {
                UpdateMaxY(stockData.HighPrice - stockData.LowPrice);
            }

            stockObject.InitializeStock(stockData, stockPosition);
        }

        public void ShowStockChart(Corporation corporation)
        {
            float xSize = 50f;
            for (int offset = 0, index = MarketManager.Instance.StockCount-1; 0 <= index; offset++, index--)
            {
                float xPosition = offset * xSize;
                float yPosition = corporation.stockData[index].MarketPrice;
                Vector2 stockPosition = new Vector2(xPosition, yPosition);
                CreateStockObject(corporation, index, stockPosition);
                break;
            }
        }

        private void UpdateMaxY(int valueY)
        {
            int divisor = 1;
            int quotient = 0;
            int remainder = 0;

            while (true)
            {
                quotient = valueY / divisor;
                if (quotient < 10)
                {
                    remainder = valueY % divisor;
                    if (remainder == 0)
                    {
                        MaxY = divisor * quotient;
                        return;
                    }
                    else
                    {
                        MaxY = divisor * (quotient + 1);
                        return;
                    }
                }

                divisor *= 10;
            }
        }
    }
}