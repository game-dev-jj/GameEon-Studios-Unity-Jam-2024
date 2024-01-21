using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;
using TMPro;

public class Keybinding : MonoBehaviour
{
    [SerializeField] Transform keybindPanel;

    [SerializeField] Button[] keyBtns;

    //TMP_Text keyText;
    Event keyEvent;
    KeyCode newKey;

    bool waitingForKey;

    void Start()
    {
        keybindPanel.gameObject.SetActive(false);
        waitingForKey = false;

        for (int i = 0; i < keyBtns.Length; i++)
        {
            keyBtns[i].GetComponentInChildren<TMP_Text>().text = KeysManager.KM.keys[i].keyCode.ToString();

            var index = i;
            keyBtns[i].onClick.AddListener(() => { StartAssignment(index); });
        }
    }

    void OnGUI()
    {
        keyEvent = Event.current;
        
        if (keyEvent.isKey && waitingForKey)
        {
            newKey = keyEvent.keyCode;
            waitingForKey = false;
        }
    }

    public void StartAssignment(int keyIndex)
    {
        if (!waitingForKey)
            StartCoroutine(AssignKey(keyIndex));
    }
    
    IEnumerator WaitForKey()
    {
        while (!keyEvent.isKey)
            yield return null;
    }
    
    public IEnumerator AssignKey(int keyIndex)
    {
        waitingForKey = true;

        keyBtns[keyIndex].GetComponentInChildren<TMP_Text>().text = "Waiting...";
        yield return WaitForKey();

        KeysManager.KM.keys[keyIndex].keyCode = newKey;
        keyBtns[keyIndex].GetComponentInChildren<TMP_Text>().text = KeysManager.KM.keys[keyIndex].keyCode.ToString();
        PlayerPrefs.SetString(KeysManager.KM.keys[keyIndex].keyName, KeysManager.KM.keys[keyIndex].keyCode.ToString());
    }
}

