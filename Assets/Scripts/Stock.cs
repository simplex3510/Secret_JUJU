using Manager;
using System;
using UnityEngine;
using UnityEngine.UI;

public class StockData : ScriptableObject
{
    

    
}


public class Stock : MonoBehaviour
{
    [Header("Components")]
    [SerializeField] private Image image;
    [SerializeField] private RectTransform rectTransform;

    [SerializeField] public float StockPrice { get; private set; }
    [SerializeField] public bool IsProfit;

    // get to MarketManager
    private float WIDTH;

    private void Awake()
    {
        WIDTH = MarketManager.Instance.GetStockWidth();
        image = GetComponent<Image>();
        rectTransform = GetComponent<RectTransform>();
    }

    public void SetStockPrice(float stockPrice) => StockPrice = stockPrice;
    public void SetIsProfit(bool isProfit) => IsProfit = isProfit;

    public void SetColor()
    {
        if (image == null)
        {
            Debug.LogError("Stock/SetColor Error");
            return;
        }

        image.color = IsProfit ? Color.red : Color.blue;
    }

    public void SetRectTranform(bool isPreProfit)
    {
        if (rectTransform == null)
        {
            Debug.LogError("Stock/SetRectTranform Error");
            return;
        }

        rectTransform.anchoredPosition = UIManager.Instance.AlignStockPosition(isPreProfit, IsProfit, StockPrice);
        rectTransform.sizeDelta = new Vector2(WIDTH, StockPrice);
    }

    public void SetInitRectTranform()
    {
        if (rectTransform == null)
        {
            Debug.LogError("Stock/SetRectTranform Error");
            return;
        }

        rectTransform.anchoredPosition = UIManager.Instance.AlignStockPosition(StockPrice);
        rectTransform.sizeDelta = new Vector2(WIDTH, StockPrice);
    }
}