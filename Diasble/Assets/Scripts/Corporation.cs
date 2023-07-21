using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Manager;

public class Corporation : MonoBehaviour/*, IObservable*/
{
    [Header("Parent")]
    [SerializeField] private Transform parent;

    [Header("Prefabs")]
    [SerializeField] private GameObject StockObject;

    [Header("Corporation Properties")]
    [SerializeField] private float growth = 0;
    [SerializeField] private float stability = 0;
    [SerializeField] private float totalValue = 0;
    [SerializeField] private List<Stock> stockList = null;

    private void Awake()
    {
        StartCoroutine(OperateEnterprise());
    }


    public IEnumerator OperateEnterprise()
    {
        int loopCount = 0;

        float prePrice;
        bool isPreProfit;
        float tempPrice;
        bool isProfit;

        // first stock generate
        InitializeCorporation();

        while (stockList.Count < MarketManager.Instance.GetInitStockCount())
        {
            GameObject newStockObject = Instantiate(StockObject, parent);
            Stock newStock = newStockObject.GetComponent<Stock>();

            int stockCount = stockList.Count;
            prePrice = stockList[stockCount - 1].StockPrice;
            isPreProfit = stockList[stockCount - 1].IsProfit;
            tempPrice = MarketManager.Instance.CreateValueByRandomWalk();
            isProfit = (0f < tempPrice - prePrice) ? true : false;

            newStock.SetStockPrice(tempPrice);
            newStock.SetIsProfit(isProfit);
            newStock.SetColor();
            newStock.SetRectTranform(isPreProfit);

            totalValue += isProfit ? tempPrice : -tempPrice;
            if (totalValue <= 0f)
            {
                Debug.LogWarning("Bankruptcy!");
                yield break;
            }

            stockList.Add(newStock);
            yield return new WaitForSeconds(MarketManager.Instance.GetTimeStep());

            if (loopCount++ == 1000)
            {
                Debug.LogWarning("Loop");
                yield break;
            }
        }
    }

    private void InitializeCorporation()
    {
        GameObject newStockObject = Instantiate(StockObject, parent);
        Stock newStock = newStockObject.GetComponent<Stock>();

        float tempPrice;
        bool isProfit;

        tempPrice = MarketManager.Instance.InitailizeValue();
        isProfit = true;

        newStock.SetStockPrice(tempPrice);
        newStock.SetIsProfit(isProfit);
        newStock.SetColor();
        newStock.SetInitRectTranform();

        totalValue += tempPrice;
        if (stockList == null)
        {
            Debug.LogWarning($"Stock list is empty");
            // corporationData.StockList = new List<Stock>();
        }
        stockList.Add(newStock);
    }
}
