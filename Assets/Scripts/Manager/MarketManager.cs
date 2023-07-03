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
        [SerializeField] private float timeStep;            // 시간폭(가로)
        [SerializeField] private float volatilityGlobal;    // 변동폭(세로)
        [SerializeField] private float meanReturn;          // 평균 수익률
        [SerializeField] private int   initStockCount;      // 초기 주식 개수
        [SerializeField] private int   refStockCount;       // 참조 주식 개수
        [SerializeField] private float STOCK_WIDTH;         // 포인트 간 간격
        [SerializeField] private float MIN_VALUE;           // 최저 변화율
        [SerializeField] private float MAX_VALUE;           // 최고 변화율

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
            // 현재 주가 변화율
            float changeRatio = 1f + (Random.Range(-0.5f, 0.5f + Mathf.Epsilon) * volatilityGlobal);
            float randomPrice = Random.Range(1f, 100f);

            // 시장 전체 변동폭을 반영한 값 반환
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

        //    // 가격 변동률 모델에 따라 주가를 계산 -> 
        //    float drift = meanReturn * timeStep;

        //    /* 기업 안정성 */
        //    //drift = Random.Range(0, 2) == 0 ? -drift : drift;
        //    //drift = drift < 0 ? drift/2f : drift;
        //    /* 기업 안정성*/

        //    // 
        //    float volatilityFactor = volatilityGlobal * Mathf.Sqrt(timeStep);

        //    float prePrice = lineRenderer.GetPosition(lineRenderer.positionCount - 1).y;
        //    float curPrice = prePrice + (drift + volatilityFactor * GenerateGaussianRandomValue());
        //    return curPrice;
        //}

        private float GenerateGaussianRandomValue()
        {
            // Box-Muller 변환 알고리즘을 사용하여 가우시안 분포에서 랜덤 변수를 추출합니다.
            float uniform1 = 1f - Random.Range(0f, 1f + Mathf.Epsilon); // 0과 1 사이의 균일 분포에서 값 추출
            float uniform2 = 1f - Random.Range(0f, 1f + Mathf.Epsilon); // 0과 1 사이의 균일 분포에서 값 추출

            float value = Mathf.Sqrt(-2f * Mathf.Log(uniform1)) * Mathf.Cos(2f * Mathf.PI * uniform2);

            return value;
        }

        private IEnumerator ProcessTimeStep()
        {
            yield break;
        }

    }
}

