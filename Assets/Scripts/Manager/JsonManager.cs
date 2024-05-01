using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Manager
{
    public class JsonManager : Singleton<JsonManager>
    {
        public JsonData JsonData { get; private set; }

        private bool isInitialized = false;

        public void ConvertJsonToData(string jsonString)
        {
            JsonData = JsonConvert.DeserializeObject<JsonData>(jsonString);
            JsonData.response.body.items.item.Reverse();
            if (isInitialized == false)
            {
                MarketManager.Instance.InitializeMarket();
                MarketManager.Instance.market.AddCorporation();
                isInitialized = true;
                GameManager.Instance.InitializeGame();
                UIManager.Instance.InitializeUI();
            }
            else
            {
                MarketManager.Instance.market.AddCorporation();
            }
        }
    }
}
