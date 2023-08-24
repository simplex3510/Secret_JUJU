using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

namespace Manager
{
    public class MarketManager : Singleton<MarketManager>
    {
        [Header("Prefabs & Object")]
        [SerializeField] private GameObject stockObject;
        [SerializeField] private RectTransform stockRectTransform;

        [Header("Common Value")]
        [SerializeField] private float timeStep;            // �ð���(����)
        [SerializeField] private float volatilityGlobal;    // ������(����)
        [SerializeField] private float meanReturn;          // ��� ���ͷ�
        [SerializeField] private int   initStockCount;      // �ʱ� �ֽ� ����
        [SerializeField] private int   refStockCount;       // ���� �ֽ� ����
        [SerializeField] private float STOCK_WIDTH;         // ����Ʈ �� ����
        [SerializeField] private float MIN_VALUE;           // ���� ��ȭ��
        [SerializeField] private float MAX_VALUE;           // �ְ� ��ȭ��

        public float GetStockWidth() => STOCK_WIDTH;
        public float GetVolatilityGlobal() => volatilityGlobal;
        public float GetTimeStep() => timeStep;
        public int GetInitStockCount() => initStockCount;
        public int GetRefStockCount() => refStockCount;

        #region Related Method of Stock

        #endregion

        #region Related Method of Enterprise

        #endregion

        public float InitailizeValue()
        {
            return Random.Range(10f, 100f);
        }

        public float CreateValueByRandomWalk()
        {
            // ���� �ְ� ��ȭ��
            float changeRatio = 1f + (Random.Range(-0.5f, 0.5f + Mathf.Epsilon) * volatilityGlobal);
            float randomPrice = Random.Range(1f, 100f);

            // ���� ��ü �������� �ݿ��� �� ��ȯ
            float price = randomPrice * changeRatio;
            return price;
        }


        //public float CreateValueByProbability(List<Stock> stockList)
        //{
        //    int loopCount = 0;

        //    int stockCount = 0;
        //    bool isProfit = Random.Range(0,2) == 0 ? false : true;

        //    if (isProfit == true)
        //    {
        //        for (int index = stockList.Count-1; stockCount != refStockCount; index--)
        //        {
        //            float preIndexPrice = lineRenderer.GetPosition(index - 1).y;
        //            float curIndexPrice = lineRenderer.GetPosition(index).y;

        //            if (0f < curIndexPrice - preIndexPrice)
        //            {
        //                stockCount++;
        //                meanReturn += curIndexPrice;
        //            }

        //            if (100 < loopCount++)
        //            {
        //                Debug.LogError("Loop");
        //                break;
        //            }
        //        }
        //    }
        //    else
        //    {
        //        for (int index = lineRenderer.positionCount - 1; stockCount != refStockCount; index--)
        //        {
        //            float preIndexPrice = lineRenderer.GetPosition(index - 1).y;
        //            float curIndexPrice = lineRenderer.GetPosition(index).y;

        //            if (curIndexPrice - preIndexPrice < 0f)
        //            {
        //                stockCount++;
        //                meanReturn -= curIndexPrice;
        //            }

        //            if (100 < loopCount++)
        //            {
        //                Debug.LogError("Loop");
        //                break;
        //            }
        //        }
        //    }
        //    meanReturn /= stockCount;

        //    // ���� ������ �𵨿� ���� �ְ��� ��� -> 
        //    float drift = meanReturn * timeStep;

        //    /* ��� ������ */
        //    //drift = Random.Range(0, 2) == 0 ? -drift : drift;
        //    //drift = drift < 0 ? drift/2f : drift;
        //    /* ��� ������*/

        //    // 
        //    float volatilityFactor = volatilityGlobal * Mathf.Sqrt(timeStep);

        //    float prePrice = lineRenderer.GetPosition(lineRenderer.positionCount - 1).y;
        //    float curPrice = prePrice + (drift + volatilityFactor * GenerateGaussianRandomValue());
        //    return curPrice;
        //}

        private float GenerateGaussianRandomValue()
        {
            // Box-Muller ��ȯ �˰����� ����Ͽ� ����þ� �������� ���� ������ �����մϴ�.
            float uniform1 = 1f - Random.Range(0f, 1f + Mathf.Epsilon); // 0�� 1 ������ ���� �������� �� ����
            float uniform2 = 1f - Random.Range(0f, 1f + Mathf.Epsilon); // 0�� 1 ������ ���� �������� �� ����

            float value = Mathf.Sqrt(-2f * Mathf.Log(uniform1)) * Mathf.Cos(2f * Mathf.PI * uniform2);

            return value;
        }

        private IEnumerator ProcessTimeStep()
        {
            yield break;
        }

    }
}

