using UnityEngine;
using UnityEngine.Assertions;

namespace Core
{
    public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
    {
        private static T globalInstance;

        private static bool applicationIsQuitting = false;

        public static T main
        {
            get
            {
                if (globalInstance == null && !applicationIsQuitting)
                {
                    T[] objects = FindObjectsOfType(typeof(T)) as T[];
                    if (objects != null && objects.Length > 0)
                    {
                        Assert.AreEqual(1, objects.Length, "You have more than one " + typeof(T).Name + " in the scene. You only need 1, it's a singleton!");

                        globalInstance = objects[0];
                    }
                    else
                    {
                        GameObject go = new GameObject(typeof(T).Name, typeof(T));
                        globalInstance = go.GetComponent<T>();
                    }
                }

                return globalInstance;
            }
        }

        protected virtual void Awake()
        {
            DontDestroyOnLoad(gameObject);
        }

        protected virtual void OnDestroy()
        {
            PreventInstantiatingOnQuit();
        }

        private void PreventInstantiatingOnQuit()
        {
            applicationIsQuitting = true;
            globalInstance = null;
        }
    }
}