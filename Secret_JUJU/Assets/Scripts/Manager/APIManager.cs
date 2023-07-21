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

        public void OnClickButton()
        {
            StartCoroutine(LoadJsonData());
        }

        public string GetJsonString() => jsonString;

        public IEnumerator LoadJsonData()
        {
            InitRequestUrl();
            AppendNumOfRows(2);
            AppendPageNo(1);

            yield return StartCoroutine(ReceiveJsonData((www) =>
            {
                jsonString = www.downloadHandler.text;
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

        private void InitRequestUrl()
        {
            requestUrl.Clear();
            requestUrl.Append(baseUrl);
            AppendServiceKey(serviceEncodingKey);
            AppendResultType("json");
        }
        private void AppendServiceKey(string serviceKey) => requestUrl.Append($"&serviceKey={serviceKey}");
        private void AppendNumOfRows(int numOfRows) => requestUrl.Append($"&numOfRows={numOfRows}");
        private void AppendPageNo(int pageNo) => requestUrl.Append($"&pageNo={pageNo}");
        private void AppendResultType(string resultType) => requestUrl.Append($"&resultType={resultType}");
        private void AppendBasDt(string basDt) => requestUrl.Append($"&basDt={basDt}");
        private void AppendBeginBasDt(string beginBasDt) => requestUrl.Append($"&beginBasDt={beginBasDt}");
        private void AppendEndBasDt(string endBasDt) => requestUrl.Append($"&endBasDt={endBasDt}");
        private void AppendLikeBasDt(string likeBasDt) => requestUrl.Append($"&likeBasDt={likeBasDt}");
        private void AppendLikeSrtnCd(string likeSrtnCd) => requestUrl.Append($"&likeSrtnCd={likeSrtnCd}");
        private void AppendIsinCd(string isinCd) => requestUrl.Append($"&isinCd={isinCd}");
        private void AppendLikeIsinCd(string likeIsinCd) => requestUrl.Append($"&likeIsinCd={likeIsinCd}");
        private void AppendItmsNm(string itmsNm) => requestUrl.Append($"&itmsNm={itmsNm}");
        private void AppendLikeItmsNm(string likeItmsNm) => requestUrl.Append($"&likeItmsNm={likeItmsNm}");
        private void AppendMrktCls(string mrktCls) => requestUrl.Append($"&mrktCls={mrktCls}");
        private void AppendBeginVs(string beginVs) => requestUrl.Append($"&beginVs={beginVs}");
        private void AppendEndVs(string endVs) => requestUrl.Append($"&endVs={endVs}");
        private void AppendBeginFltRt(string beginFltRt) => requestUrl.Append($"&beginFltRt={beginFltRt}");
        private void AppendEndFltRt(string endFltRt) => requestUrl.Append($"&endFltRt={endFltRt}");
        private void AppendBeginTrqu(string beginTrqu) => requestUrl.Append($"&beginTrqu={beginTrqu}");
        private void AppendEndTrqu(string endTrqu) => requestUrl.Append($"&endTrqu={endTrqu}");
        private void AppendBeginTrPrc(string beginTrPr) => requestUrl.Append($"&beginTrPr={beginTrPr}");
        private void AppendEndTrPrc(string endTrPrc) => requestUrl.Append($"&endTrPrc={endTrPrc}");
        private void AppendBeginLstgStCnt(string beginLstgStCnt) => requestUrl.Append($"beginLstgStCnt={beginLstgStCnt}");
        private void AppendEndLstgStCnt(string endLstgStCnt) => requestUrl.Append($"&endLstgStCnt={endLstgStCnt}");
        private void AppendBeginMrktTotAmt(string beginMrktTotAmt) => requestUrl.Append($"&beginMrktTotAmt={beginMrktTotAmt}");
        private void AppendEndMrktTotAmt(string endMrktTotAmt) => requestUrl.Append($"&endMrktTotAmt={endMrktTotAmt}");

    }
}
