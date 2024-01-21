using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewKeyCode : MonoBehaviour
{
    public static KeyCode topLeftKey;
    public static KeyCode bottomLeftKey;
    public static KeyCode topRightKey;
    public static KeyCode bottomRightKey;
    
    void LateUpdate()
    {
        topLeftKey = KeysManager.KM.keys[0].keyCode;
        bottomLeftKey = KeysManager.KM.keys[1].keyCode;
        topRightKey = KeysManager.KM.keys[2].keyCode;
        bottomRightKey = KeysManager.KM.keys[3].keyCode;
    }
}
