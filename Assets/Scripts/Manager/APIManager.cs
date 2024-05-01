using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using UnityEngine;
using UnityEngine.Networking;

namespace Manager
{
    [Serializable]
    public class APIManager : Singleton<APIManager>
    {
        private static string baseUrl = "http://apis.data.go.kr/1160100/service/GetStockSecuritiesInfoService/getStockPriceInfo?";
        private static string serviceEncodingKey = "51d6PLghYwGUH7KCol9ES%2FxPYm%2Fk7LrIpnSEGM3j0NM%2BiVM1EhcRC%2BQmuNXXY1iT9LZvoRoREYkJ95R1iQNibA%3D%3D";
        private static string serviceDecodingKey = "51d6PLghYwGUH7KCol9ES/xPYm/k7LrIpnSEGM3j0NM+iVM1EhcRC+QmuNXXY1iT9LZvoRoREYkJ95R1iQNibA==";
        private static StringBuilder requestUrl = new StringBuilder();
        private static string jsonString = string.Empty;

        public void OnClick()
        {
            StartCoroutine(LoadJsonData());
        }

        public string GetJsonString() => jsonString;

        private IEnumerator LoadJsonData()
        {
            InitRequestUrl("삼성전자", "20200000", "20210000");
            yield return StartCoroutine(ReceiveJsonData((www) =>
            {
                jsonString = www.downloadHandler.text;
                JsonManager.Instance.ConvertJsonToData(jsonString);
            }));
        }

        private IEnumerator ReceiveJsonData(Action<UnityWebRequest> callback)
        {
            using (UnityWebRequest www = UnityWebRequest.Get(requestUrl.ToString()))
            {
                yield return www.SendWebRequest();

                if (www.result == UnityWebRequest.Result.Success)
                {
                    callback(www);
                    yield break;
                }
                else
                {
                    Debug.Log($"서버로부터 JSON 데이터를 받는 중 오류가 발생했습니다: {www.error}");
                }
            }
        }

        private void InitRequestUrl(string itemName, string startDate, string endDate)
        {
            InitRequestUrl();
            AppendItemsName(itemName);
            AppendBeginBaseDate(startDate);
            AppendEndBaseDate(endDate);
        }

        private void InitRequestUrl()
        {
            requestUrl.Clear();
            requestUrl.Append(baseUrl);
            AppendServiceKey(serviceEncodingKey);
            AppendResultType("json");
            AppendNumOfRows(365);
            AppendPageNo(1);
        }

        private void AppendServiceKey(string serviceKey) => requestUrl.Append($"&serviceKey={serviceKey}");
        /// <summary> 한 페이지 결과 수 </summary>
        /// <param name="serviceKey"></param>
        private void AppendNumOfRows(int numOfRows) => requestUrl.Append($"&numOfRows={numOfRows}");
        /// <summary> 페이지 번호 </summary>
        /// <param name="pageNo"></param>
        private void AppendPageNo(int pageNo) => requestUrl.Append($"&pageNo={pageNo}");
        /// <summary> 구분(xml, json), Default: xml </summary>
        /// <param name="resultType"></param>
        private void AppendResultType(string resultType) => requestUrl.Append($"&resultType={resultType}");
        /// <summary> 검색값과 기준일자가 일치하는 데이터를 검색 </summary>
        /// <param name="basDt"></param>
        private void AppendBaseDate(string basDt) => requestUrl.Append($"&basDt={basDt}");
        /// <summary> 기준일자가 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginBasDt"></param>
        private void AppendBeginBaseDate(string beginBasDt) => requestUrl.Append($"&beginBasDt={beginBasDt}");
        /// <summary> 기준일자가 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endBasDt"></param>
        private void AppendEndBaseDate(string endBasDt) => requestUrl.Append($"&endBasDt={endBasDt}");
        /// <summary> 기준일자값이 검색값을 포함하는 데이터를 검색 </summary>
        /// <param name="likeBasDt"></param>
        private void AppendLikeBaseDate(string likeBasDt) => requestUrl.Append($"&likeBasDt={likeBasDt}");
        /// <summary> 단축코드가 검색값을 포함하는 데이터를 검색 </summary>
        /// <param name="likeSrtnCd"></param>
        private void AppendLikeShrotenCode(string likeSrtnCd) => requestUrl.Append($"&likeSrtnCd={likeSrtnCd}");
        /// <summary> 검색값과 ISIN코드이 일치하는 데이터를 검색 </summary>
        /// <param name="isinCd"></param>
        private void AppendIsinCode(string isinCd) => requestUrl.Append($"&isinCd={isinCd}");
        /// <summary> ISIN코드가 검색값을 포함하는 데이터를 검색 </summary>
        /// <param name="likeIsinCd"></param>
        private void AppendLikeIsinCode(string likeIsinCd) => requestUrl.Append($"&likeIsinCd={Uri.EscapeDataString(likeIsinCd)}");
        /// <summary> 검색값과 종목명이 일치하는 데이터를 검색 </summary>
        /// <param name="itmsNm"></param>
        private void AppendItemsName(string itmsNm) => requestUrl.Append($"&itmsNm={Uri.EscapeDataString(itmsNm)}");
        /// <summary> 종목명이 검색값을 포함하는 데이터를 검색 </summary>
        /// <param name="likeItmsNm"></param>
        private void AppendLikeItemsName(string likeItmsNm) => requestUrl.Append($"&likeItmsNm={likeItmsNm}");
        /// <summary> 검색값과 시장구분이 일치하는 데이터를 검색 </summary>
        /// <param name="mrktCls"></param>
        private void AppendMarketClassification(string mrktCls) => requestUrl.Append($"&mrktCls={mrktCls}");
        /// <summary> 대비가 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginVs"></param>
        private void AppendBeginVersus(string beginVs) => requestUrl.Append($"&beginVs={beginVs}");
        /// <summary> 대비가 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endVs"></param>
        private void AppendEndVersus(string endVs) => requestUrl.Append($"&endVs={endVs}");
        /// <summary> 등락률이 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginFltRt"></param>
        private void AppendBeginFloatingRate(string beginFltRt) => requestUrl.Append($"&beginFltRt={beginFltRt}");
        /// <summary> 등락률이 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endFltRt"></param>
        private void AppendEndFloatingRate(string endFltRt) => requestUrl.Append($"&endFltRt={endFltRt}");
        /// <summary> 거래량이 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginTrqu"></param>
        private void AppendBeginTradeQuantity(string beginTrqu) => requestUrl.Append($"&beginTrqu={beginTrqu}");
        /// <summary> 거래량이 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endTrqu"></param>
        private void AppendEndTradeQuantity(string endTrqu) => requestUrl.Append($"&endTrqu={endTrqu}");
        /// <summary> 거래대금이 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginTrPr"></param>
        private void AppendBeginTradePrice(string beginTrPr) => requestUrl.Append($"&beginTrPr={beginTrPr}");
        /// <summary> 거래대금이 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endTrPrc"></param>
        private void AppendEndTradePrice(string endTrPrc) => requestUrl.Append($"&endTrPrc={endTrPrc}");
        /// <summary> 상장주식수가 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginLstgStCnt"></param>
        private void AppendBeginListingStockCount(string beginLstgStCnt) => requestUrl.Append($"beginLstgStCnt={beginLstgStCnt}");
        /// <summary> 상장주식수가 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endLstgStCnt"></param>
        private void AppendEndListingStockCount(string endLstgStCnt) => requestUrl.Append($"&endLstgStCnt={endLstgStCnt}");
        /// <summary> 시가총액이 검색값보다 크거나 같은 데이터를 검색 </summary>
        /// <param name="beginMrktTotAmt"></param>
        private void AppendBeginMarketTotalAmounts(string beginMrktTotAmt) => requestUrl.Append($"&beginMrktTotAmt={beginMrktTotAmt}");
        /// <summary> 시가총액이 검색값보다 작은 데이터를 검색 </summary>
        /// <param name="endMrktTotAmt"></param>
        private void AppendEndMarketTotalAmounts(string endMrktTotAmt) => requestUrl.Append($"&endMrktTotAmt={endMrktTotAmt}");
    }
}
