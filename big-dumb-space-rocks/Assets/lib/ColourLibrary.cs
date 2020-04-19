using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ColourLibrary : Singleton<ColourLibrary>
{
    public Entry[] entries;

    public Color lookup(string name)
    {
        foreach (Entry entry in this.entries)
        {
            if (entry.name == name)
            {
                return entry.value;
            }
        }

        return new Color(1.0f, 0.0f, 0.0f, 1.0f);
    }

    [System.Serializable]
    public struct Entry
    {
        public string name;
        public Color value;
    }
}


