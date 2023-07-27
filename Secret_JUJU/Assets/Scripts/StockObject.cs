using Manager;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class StockObject : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform candleRect;
    [SerializeField] private RectTransform stickRect;

    StockData stockData;

    public void InitializeStock(StockData stockData, Vector2 stockPosition)
    {
        rectTransform = GetComponent<RectTransform>();
        candleRect = rectTransform.GetChild(0).GetComponent<RectTransform>();
        stickRect = rectTransform.GetChild(1).GetComponentInChildren<RectTransform>();

        this.stockData = stockData;

        InitializeCandle(stockPosition);
        //InitializeStick(stockPosition);
    }

    private void InitializeCandle(Vector2 anchoredPosition)
    {
        if (0 < stockData.Versus)
        {
            candleRect.GetComponent<Image>().color = Color.red;

            candleRect.anchorMin = new Vector2(0, 0);
            candleRect.anchorMax = new Vector2(0, 0);
            candleRect.pivot = new Vector2(0, 0);

            candleRect.sizeDelta = new Vector2(50, (((stockData.ClosingPrice - stockData.MarketPrice) / UIManager.Instance.MaxY) * 520));
            candleRect.anchoredPosition = new Vector2(anchoredPosition.x, ((stockData.MarketPrice / UIManager.Instance.MaxY) * 520));
        }
        else
        {
            candleRect.GetComponent<Image>().color = Color.blue;

            candleRect.anchorMin = new Vector2(0, 0);
            candleRect.anchorMax = new Vector2(0, 0);
            candleRect.pivot = new Vector2(0, 0);

            candleRect.sizeDelta = new Vector2(50, (((stockData.MarketPrice - stockData.ClosingPrice) / UIManager.Instance.MaxY) * 520));
            candleRect.anchoredPosition = new Vector2(anchoredPosition.x, ((stockData.ClosingPrice / UIManager.Instance.MaxY) * 520));
        }
    }

    private void InitializeStick(Vector2 anchoredPosition)
    {
        if (0 < stockData.Versus)
        {
            stickRect.GetComponent<Image>().color = Color.red;
        }
        else
        {
            stickRect.GetComponent<Image>().color = Color.blue;
        }

        stickRect.anchorMin = new Vector2(0.5f, 0f);
        stickRect.anchorMax = new Vector2(0.5f, 0f);
        stickRect.pivot = new Vector2(0.5f, 0f);

        stickRect.sizeDelta = new Vector2(10, (((stockData.ClosingPrice - stockData.MarketPrice) / 1000000) * 520));
        stickRect.anchoredPosition = new Vector2(anchoredPosition.x/2, ((stockData.LowPrice / UIManager.Instance.MaxY) * 520));
    }
}
