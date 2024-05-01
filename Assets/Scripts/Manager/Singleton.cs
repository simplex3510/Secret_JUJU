using UnityEngine;

namespace Manager
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T instance;

        public static T Instance
        {
            get
            {
                if (instance == null)
                {
                    instance = FindObjectOfType<T>();
                    if (instance == null)
                    {
                        GameObject manager = new GameObject(typeof(T).Name);
                        instance = manager.AddComponent<T>();
                        DontDestroyOnLoad(instance);
                    }
                }

                return instance;
            }
        }
    }
}