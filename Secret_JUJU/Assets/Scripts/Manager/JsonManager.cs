using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Manager
{
    public class JsonManager : Singleton<JsonManager>
    {
        public JsonData JsonData { get; private set; }

        public void ConvertJsonToData(string jsonString)
        {
            JsonData = JsonConvert.DeserializeObject<JsonData>(jsonString);
            MarketManager.Instance.InitializeMarket();
        }
    }
}
