using UnityEngine;

// https://answers.unity.com/questions/1408574/destroying-and-recreating-a-singleton.html

public class Singleton<T> : MonoBehaviour where T : Singleton<T>
{
    private static T m_Instance = null;

    public static T Instance
    {
        get
        {
            if (m_Instance == null)
            {
                m_Instance = FindObjectOfType<T>();
            }
            return m_Instance;
        }
    }
}

