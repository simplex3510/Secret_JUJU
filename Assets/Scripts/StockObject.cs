using Manager;
using Newtonsoft.Json.Linq;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockObject : MonoBehaviour
{
    [SerializeField] public StockData stockData { get; private set; }
    [SerializeField] public RectTransform rectTransform { get; private set; }

    [SerializeField] private RectTransform candleRect;
    [SerializeField] private RectTransform stickRect;

    private readonly int STOCK_SIZE_X = 50;
    private readonly int CANDLE_SIZE_X = 50;
    private readonly int STICK_SIZE_X = 25;

    public void InitializeStock(StockData stockData, Vector2 stockMaxVector)
    {
        this.stockData = stockData;

        rectTransform = GetComponent<RectTransform>();
        candleRect = rectTransform.GetChild(0).GetComponent<RectTransform>();
        stickRect = rectTransform.GetChild(1).GetComponentInChildren<RectTransform>();

        rectTransform.sizeDelta = new Vector2(STOCK_SIZE_X, (stockData.HighPrice - stockData.LowPrice) * UIManager.Instance.CORRECTION_VALUE);
        rectTransform.anchoredPosition = new Vector2(stockMaxVector.x, (stockData.LowPrice - UIManager.Instance.AxisMinY) * UIManager.Instance.CORRECTION_VALUE);

        InitializeCandle();
        InitializeStick();
    }

    private void InitializeCandle()
    {
        if (0 < stockData.Versus)
        {
            candleRect.GetComponent<Image>().color = Color.red;
        }
        else
        {
            candleRect.GetComponent<Image>().color = Color.blue;
        }

        //candleRect.anchorMin = new Vector2(0, 0);
        //candleRect.anchorMax = new Vector2(0, 0);
        //candleRect.pivot = new Vector2(0, 0);

        if (stockData.ClosingPrice < stockData.MarketPrice)
        {
            float candleY = stockData.MarketPrice - stockData.ClosingPrice;
            candleRect.sizeDelta = new Vector2(CANDLE_SIZE_X, candleY * UIManager.Instance.CORRECTION_VALUE);
            candleRect.anchoredPosition = new Vector2(0, (stockData.ClosingPrice - stockData.LowPrice) * UIManager.Instance.CORRECTION_VALUE);
        }
        else
        {
            float candleY = stockData.ClosingPrice - stockData.MarketPrice;
            candleRect.sizeDelta = new Vector2(CANDLE_SIZE_X, candleY * UIManager.Instance.CORRECTION_VALUE);
            candleRect.anchoredPosition = new Vector2(0, (stockData.MarketPrice - stockData.LowPrice) * UIManager.Instance.CORRECTION_VALUE);
        }
    }

    private void InitializeStick()
    {
        if (0 < stockData.Versus)
        {
            stickRect.GetComponent<Image>().color = Color.red;
        }
        else
        {
            stickRect.GetComponent<Image>().color = Color.blue;
        }

        //stickRect.anchorMin = new Vector2(0.5f, 0f);
        //stickRect.anchorMax = new Vector2(0.5f, 0f);
        //stickRect.pivot = new Vector2(0.5f, 0f);

        stickRect.sizeDelta = new Vector2(STICK_SIZE_X, (stockData.HighPrice - stockData.LowPrice) * UIManager.Instance.CORRECTION_VALUE);
    }
}
