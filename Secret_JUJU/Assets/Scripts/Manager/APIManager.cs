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
            InitRequestUrl("�Ｚ����", "20200000", "20210000");
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
                    Debug.Log($"�����κ��� JSON �����͸� �޴� �� ������ �߻��߽��ϴ�: {www.error}");
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
        /// <summary> �� ������ ��� �� </summary>
        /// <param name="serviceKey"></param>
        private void AppendNumOfRows(int numOfRows) => requestUrl.Append($"&numOfRows={numOfRows}");
        /// <summary> ������ ��ȣ </summary>
        /// <param name="pageNo"></param>
        private void AppendPageNo(int pageNo) => requestUrl.Append($"&pageNo={pageNo}");
        /// <summary> ����(xml, json), Default: xml </summary>
        /// <param name="resultType"></param>
        private void AppendResultType(string resultType) => requestUrl.Append($"&resultType={resultType}");
        /// <summary> �˻����� �������ڰ� ��ġ�ϴ� �����͸� �˻� </summary>
        /// <param name="basDt"></param>
        private void AppendBaseDate(string basDt) => requestUrl.Append($"&basDt={basDt}");
        /// <summary> �������ڰ� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginBasDt"></param>
        private void AppendBeginBaseDate(string beginBasDt) => requestUrl.Append($"&beginBasDt={beginBasDt}");
        /// <summary> �������ڰ� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endBasDt"></param>
        private void AppendEndBaseDate(string endBasDt) => requestUrl.Append($"&endBasDt={endBasDt}");
        /// <summary> �������ڰ��� �˻����� �����ϴ� �����͸� �˻� </summary>
        /// <param name="likeBasDt"></param>
        private void AppendLikeBaseDate(string likeBasDt) => requestUrl.Append($"&likeBasDt={likeBasDt}");
        /// <summary> �����ڵ尡 �˻����� �����ϴ� �����͸� �˻� </summary>
        /// <param name="likeSrtnCd"></param>
        private void AppendLikeShrotenCode(string likeSrtnCd) => requestUrl.Append($"&likeSrtnCd={likeSrtnCd}");
        /// <summary> �˻����� ISIN�ڵ��� ��ġ�ϴ� �����͸� �˻� </summary>
        /// <param name="isinCd"></param>
        private void AppendIsinCode(string isinCd) => requestUrl.Append($"&isinCd={isinCd}");
        /// <summary> ISIN�ڵ尡 �˻����� �����ϴ� �����͸� �˻� </summary>
        /// <param name="likeIsinCd"></param>
        private void AppendLikeIsinCode(string likeIsinCd) => requestUrl.Append($"&likeIsinCd={Uri.EscapeDataString(likeIsinCd)}");
        /// <summary> �˻����� ������� ��ġ�ϴ� �����͸� �˻� </summary>
        /// <param name="itmsNm"></param>
        private void AppendItemsName(string itmsNm) => requestUrl.Append($"&itmsNm={Uri.EscapeDataString(itmsNm)}");
        /// <summary> ������� �˻����� �����ϴ� �����͸� �˻� </summary>
        /// <param name="likeItmsNm"></param>
        private void AppendLikeItemsName(string likeItmsNm) => requestUrl.Append($"&likeItmsNm={likeItmsNm}");
        /// <summary> �˻����� ���屸���� ��ġ�ϴ� �����͸� �˻� </summary>
        /// <param name="mrktCls"></param>
        private void AppendMarketClassification(string mrktCls) => requestUrl.Append($"&mrktCls={mrktCls}");
        /// <summary> ��� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginVs"></param>
        private void AppendBeginVersus(string beginVs) => requestUrl.Append($"&beginVs={beginVs}");
        /// <summary> ��� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endVs"></param>
        private void AppendEndVersus(string endVs) => requestUrl.Append($"&endVs={endVs}");
        /// <summary> ������� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginFltRt"></param>
        private void AppendBeginFloatingRate(string beginFltRt) => requestUrl.Append($"&beginFltRt={beginFltRt}");
        /// <summary> ������� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endFltRt"></param>
        private void AppendEndFloatingRate(string endFltRt) => requestUrl.Append($"&endFltRt={endFltRt}");
        /// <summary> �ŷ����� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginTrqu"></param>
        private void AppendBeginTradeQuantity(string beginTrqu) => requestUrl.Append($"&beginTrqu={beginTrqu}");
        /// <summary> �ŷ����� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endTrqu"></param>
        private void AppendEndTradeQuantity(string endTrqu) => requestUrl.Append($"&endTrqu={endTrqu}");
        /// <summary> �ŷ������ �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginTrPr"></param>
        private void AppendBeginTradePrice(string beginTrPr) => requestUrl.Append($"&beginTrPr={beginTrPr}");
        /// <summary> �ŷ������ �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endTrPrc"></param>
        private void AppendEndTradePrice(string endTrPrc) => requestUrl.Append($"&endTrPrc={endTrPrc}");
        /// <summary> �����ֽļ��� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginLstgStCnt"></param>
        private void AppendBeginListingStockCount(string beginLstgStCnt) => requestUrl.Append($"beginLstgStCnt={beginLstgStCnt}");
        /// <summary> �����ֽļ��� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endLstgStCnt"></param>
        private void AppendEndListingStockCount(string endLstgStCnt) => requestUrl.Append($"&endLstgStCnt={endLstgStCnt}");
        /// <summary> �ð��Ѿ��� �˻������� ũ�ų� ���� �����͸� �˻� </summary>
        /// <param name="beginMrktTotAmt"></param>
        private void AppendBeginMarketTotalAmounts(string beginMrktTotAmt) => requestUrl.Append($"&beginMrktTotAmt={beginMrktTotAmt}");
        /// <summary> �ð��Ѿ��� �˻������� ���� �����͸� �˻� </summary>
        /// <param name="endMrktTotAmt"></param>
        private void AppendEndMarketTotalAmounts(string endMrktTotAmt) => requestUrl.Append($"&endMrktTotAmt={endMrktTotAmt}");
    }
}
