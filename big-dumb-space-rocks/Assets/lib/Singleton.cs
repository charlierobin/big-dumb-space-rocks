﻿using UnityEngine;

// https://answers.unity.com/questions/1408574/destroying-and-recreating-a-singleton.html

// Inherit from this base class to create a singleton.
// e.g. public class MyClassName : Singleton<MyClassName> {}

public class Singleton<T> : MonoBehaviour where T : MonoBehaviour
{
    // Check to see if we're about to be destroyed

    private static bool m_ShuttingDown = false;
    private static object m_Lock = new object();
    private static T m_Instance;

    // Access singleton instance through this property

    public static T Instance
    {
        get
        {
            if (m_ShuttingDown)
            {
                //Debug.LogWarning("[Singleton] Instance '" + typeof(T) + "' already destroyed. Returning null.");
                return null;
            }

            lock (m_Lock)
            {
                if (m_Instance == null)
                {
                    //Debug.Log(typeof(T).ToString() + " search");

                    // Search for existing instance.
                    m_Instance = (T)FindObjectOfType(typeof(T));

                    // Create new instance if one doesn't already exist.
                    if (m_Instance == null)
                    {
                        //Debug.Log(typeof(T).ToString() + " null");

                        // Need to create a new GameObject to attach the singleton to.
                        //var singletonObject = new GameObject();
                        //m_Instance = singletonObject.AddComponent<T>();
                        //singletonObject.name = typeof(T).ToString() + " (Singleton)";

                        // Make instance persistent.
                        //DontDestroyOnLoad(singletonObject);
                    }
                }

                return m_Instance;
            }
        }
    }

    private void OnApplicationQuit()
    {
        m_Instance = null;
        m_ShuttingDown = true;

        //Debug.Log(typeof(T).ToString() + " instance cleared");
    }

    private void OnDestroy()
    {
        //m_ShuttingDown = true;
    }
}
