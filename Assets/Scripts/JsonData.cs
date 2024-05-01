using Newtonsoft.Json;
using System.Collections;
using System.Collections.Generic;

[System.Serializable]
public class JsonData
{
    public Response response { get; set; }
}

[System.Serializable]
public class Response
{
    public Header header { get; set; }
    public Body body { get; set; }
}

[System.Serializable]
public class Header
{
    public string resultCode { get; set; }
    public string resultMsg { get; set; }
}

[System.Serializable]
public class Body
{
    public int numOfRows { get; set; }
    public int pageNo { get; set; }
    public int totalCount { get; set; }
    public Items items { get; set; }
}

[System.Serializable]
public class Items
{
    public List<Item> item { get; set; }
}

[System.Serializable]
public class Item
{
    public string basDt { get; set; }
    public string srtnCd { get; set; }
    public string isinCd { get; set; }
    public string itmsNm { get; set; }
    public string mrktCtg { get; set; }
    public string clpr { get; set; }
    public string vs { get; set; }
    public string fltRt { get; set; }
    public string mkp { get; set; }
    public string hipr { get; set; }
    public string lopr { get; set; }
    public string trqu { get; set; }
    public string trPrc { get; set; }
    public string lstgStCnt { get; set; }
    public string mrktTotAmt { get; set; }
}