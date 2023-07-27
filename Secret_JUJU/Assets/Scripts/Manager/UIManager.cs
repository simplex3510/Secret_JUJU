using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    // Stock Graph UI
    public partial class UIManager : Singleton<UIManager>
    {
        public float MaxY { get; private set; } = 100000f;
        public float GraphHeight { get; private set; }

        [SerializeField] private RectTransform graphContainer = null;

        private void Awake()
        {
            GraphHeight = graphContainer.sizeDelta.y;
        }

        public void CreateStockObject(Corporation corporation, int count, Vector2 stockPosition)
        {
            GameObject stockObject = Instantiate(Resources.Load<GameObject>("Prefabs/Stock"));
            stockObject.transform.SetParent(graphContainer.transform, false);
            StockData stockData = corporation.stockData[count];
            stockObject.GetComponent<StockObject>().InitializeStock(stockData, stockPosition);
        }

        public void ShowStockChart(Corporation corporation)
        {
            float xSize = 50f;
            for (int offset = 0, index = MarketManager.Instance.StockCount-1; 0 <= index; offset++, index--)
            {
                float xPosition = xSize + (offset * xSize);
                float yPosition = corporation.stockData[index].MarketPrice;
                Vector2 stockPosition = new Vector2(xPosition, yPosition);
                CreateStockObject(corporation, index, stockPosition);
                break;
            }
        }
    }
}