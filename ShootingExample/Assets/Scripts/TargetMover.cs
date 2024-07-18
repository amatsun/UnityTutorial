using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class TargetMover : MonoBehaviour
{
    [SerializeField]
    Transform movingTarget;
    Vector3 originalPos;
    [SerializeField]
    float radius;
    [SerializeField]
    float cutLen;
    [SerializeField]
    float hz;
    [SerializeField]
    Transform direcitonIndicator;
    float seqTime;
    float initialTime;
    // Start is called before the first frame update
    void Start()
    {
        //���������A1�����̎��ԁA�����ʒu���Z�b�g
        initialTime = Time.time;
        seqTime = 1f / hz;
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //���݂̌o�ߎ��Ԃ������Ŋ������]��
        float currentTime = Mathf.Repeat(Time.time - initialTime, seqTime);

        //Sin�֐��Ŏ����I�ȓ����ɕϊ�
        float x = radius * Mathf.Sin(currentTime / seqTime * 2f * Mathf.PI);
        
        //cutLen�������Ă�����cutLen�ɃJ�b�g
        if(Mathf.Abs(x) > cutLen)
        {
            x = cutLen * Mathf.Sign(x);
        }

        //���������ɃI�t�Z�b�g���v�Z
        Vector3 offset = direcitonIndicator.forward * x;

        //�����ʒu�ɃI�t�Z�b�g�����Z
        movingTarget.position = originalPos + offset;
    }
}
