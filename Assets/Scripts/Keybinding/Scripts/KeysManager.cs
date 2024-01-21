using UnityEngine;

public class KeysManager : MonoBehaviour
{
    public static KeysManager KM;

    public Key[] keys;

    void Awake()
    {
        if (KM == null)
        {
            DontDestroyOnLoad(gameObject);
            KM = this;
        }
        else if (KM != this)
        {
            Destroy(gameObject);
        }

        for (int i = 0; i < keys.Length; i++)
        {
            keys[i].keyCode = (KeyCode)System.Enum.Parse(typeof(KeyCode), PlayerPrefs.GetString(keys[i].keyName, keys[i].keyCode.ToString()));
        }
    }
}

[System.Serializable]
public class Key
{
    public string keyName;
    public KeyCode keyCode;
}