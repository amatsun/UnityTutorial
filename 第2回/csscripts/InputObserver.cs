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
            Debug.Log("Enter��������܂���");
        }
        //0: ���{�^��
        //1: �E�{�^��
        //2: �}�E�X�z�C�[��
        if (Input.GetMouseButton(0))
        {
            Debug.Log("���{�^����������Ă��܂�");
            Vector2 mousePosition = Input.mousePosition;
            Debug.Log($"���݂̃}�E�X�̈ʒu��{mousePosition}�ł�");
        }        
    }
}
