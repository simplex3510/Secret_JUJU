using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Stock : MonoBehaviour
{
    [SerializeField] private RectTransform rectTransform;
    [SerializeField] private RectTransform candleRect;
    [SerializeField] private RectTransform stickRect;

    [SerializeField] private float marketPrice;
    [SerializeField] private float closingPrice;
    [SerializeField] private float highPrice;
    [SerializeField] private float lowPrice;

    private int versus;

    private void Awake()
    {
        versus = 0;
        rectTransform = GetComponent<RectTransform>();
        candleRect = rectTransform.GetChild(0).GetComponent<RectTransform>();
        Debug.Log(candleRect.name);
        stickRect = rectTransform.GetChild(1).GetComponentInChildren<RectTransform>();
        Debug.Log(stickRect.name);
        InitializeStock();
    }

    private void InitializeStock()
    {
        InitializeCandle();
        InitializeStick();
    }

    private void InitializeCandle()
    {
        if (0 < versus)
        {
            candleRect.GetComponent<Image>().color = Color.red;

            candleRect.anchorMin = new Vector2(0, 0);
            candleRect.anchorMax = new Vector2(0, 0);
            candleRect.pivot = new Vector2(0, 0);

            candleRect.sizeDelta = new Vector2(50, (((closingPrice - marketPrice) / 100) * 520));
            candleRect.anchoredPosition = new Vector2(0, ((marketPrice / 100) * 520));
        }
        else
        {
            candleRect.GetComponent<Image>().color = Color.blue;

            candleRect.anchorMin = new Vector2(0, 0);
            candleRect.anchorMax = new Vector2(0, 0);
            candleRect.pivot = new Vector2(0, 0);

            candleRect.sizeDelta = new Vector2(50, (((marketPrice - closingPrice) / 100) * 520));
            candleRect.anchoredPosition = new Vector2(0, ((closingPrice / 100) * 520));
        }
    }

    private void InitializeStick()
    {
        if (0 < versus)
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

        stickRect.sizeDelta = new Vector2(10, (((highPrice - lowPrice) / 100) * 520));
        stickRect.anchoredPosition = new Vector2(25, ((lowPrice / 100) * 520));
    }
}
