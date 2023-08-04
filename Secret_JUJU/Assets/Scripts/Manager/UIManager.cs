using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    // Stock Graph UI
    public partial class UIManager : Singleton<UIManager>
    {
        public int AxisMaxY { get; private set; } = int.MinValue;
        public int AxisMinY { get; private set; } = int.MaxValue;
        public int MinY { get; private set; } = int.MaxValue;
        public int MaxY { get; private set; } = int.MinValue;
        public int MaxX { get; private set; } = 0;

        [SerializeField] private RectTransform chartContainer;
        [SerializeField] private GameObject stockPrefab;
        private readonly int OFFSET_X = 50;
        private int stockIndex = 0;

        public void CreateStockObject(Corporation corporation, int count, Vector2 stockMaxVector)
        {
            StockObject stockObject = Instantiate(stockPrefab, chartContainer.transform, false).GetComponent<StockObject>();
            StockData stockData = corporation.stockData[count];

            stockObject.InitializeStock(stockData, stockMaxVector);
        }

        public void UpdateStockChart(Corporation corporation)
        {
            int stockVectorY = corporation.stockData[stockIndex].HighPrice - corporation.stockData[stockIndex].LowPrice;
            if (MaxY < stockVectorY)
            {
                UpdateMaxY(stockVectorY);
            }
            if (stockVectorY < MinY)
            {
                MinY = stockVectorY;
            }

            UpdateAxisMaxY(stockVectorY);
            UpdateAxisMinY(stockVectorY);

            int curStockIndex = 0;
            while (/*curStockIndex <= stockIndex &&*/ stockIndex < MarketManager.Instance.StockCount)
            {
                MaxX = OFFSET_X * curStockIndex;
                float xVector = MaxX;
                float yVector = MaxY;

                Vector2 stockMaxVector = new Vector2(xVector, yVector);
                CreateStockObject(corporation, curStockIndex, stockMaxVector);
                curStockIndex++;
                if (stockIndex == 1)
                {
                    break;
                }
                stockIndex++;
            }

            chartContainer.sizeDelta = new Vector2(MaxX, MaxY);
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
                    }
                    else
                    {
                        MaxY = divisor * (quotient + 1);
                    }
                    return;
                }

                divisor *= 10;
            }
        }

        private void UpdateAxisMaxY(int valueY) // 1501
        {
            int divisor = 1;
            int quotient = 0;
            int remainder = 0;

            while (true)
            {
                quotient = valueY / divisor;

                if(quotient == 1)
                {
                    remainder = valueY % divisor;
                    if (true)
                    {
                        AxisMaxY = divisor;
                    }
                    else
                    {
                        AxisMaxY = 5 * (divisor / 10);
                    }
                    return;
                }
                else
                {
                    divisor *= 10;
                }
            }
        }

        private void UpdateAxisMinY(int valueY) // 1501
        {
            int divisor = 1;
            int quotient = 0;
            int remainder = 0;

            while (true)
            {
                quotient = valueY / divisor;

                if (quotient == 1)
                {
                    remainder = valueY % divisor;
                    if (remainder == 0 || remainder < (divisor/2))
                    {
                        AxisMinY = divisor;
                    }
                    else
                    {
                        AxisMinY = 5 * (divisor / 10);
                    }
                    return;
                }
                else
                {
                    divisor *= 10;
                }
            }
        }
    }
}