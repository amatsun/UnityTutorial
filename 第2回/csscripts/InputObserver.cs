using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class InputObserver : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Return))
        {
            Debug.Log("Enterが押されました");
        }
        //0: 左ボタン
        //1: 右ボタン
        //2: マウスホイール
        if (Input.GetMouseButton(0))
        {
            Debug.Log("左ボタンが押されています");
            Vector2 mousePosition = Input.mousePosition;
            Debug.Log($"現在のマウスの位置は{mousePosition}です");
        }        
    }
}
