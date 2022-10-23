using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class KeyBinds : MonoBehaviour
{
    public static KeyCode upW, UpArr, DownArr, DownS, enter, exit;
    void Start()
    {
        upW = KeyCode.W;
        UpArr = KeyCode.UpArrow;
        DownArr = KeyCode.DownArrow;
        DownS = KeyCode.S;
        enter = KeyCode.Return;
        exit = KeyCode.Escape;

    }

    // Update is called once per frame
    void Update()
    {

    }
}
