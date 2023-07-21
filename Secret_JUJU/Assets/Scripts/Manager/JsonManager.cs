using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using Newtonsoft.Json;

namespace Manager
{
    public class JsonManager : Singleton<JsonManager>
    {
        public JsonData JsonData { get; private set; }

        private void Awake()
        {
            JsonData = JsonConvert.DeserializeObject<JsonData>(APIManager.Instance.GetJsonString());
        }
    }
}
