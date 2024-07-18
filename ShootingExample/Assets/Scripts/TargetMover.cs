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
        //初期時刻、1周期の時間、初期位置をセット
        initialTime = Time.time;
        seqTime = 1f / hz;
        originalPos = transform.position;
    }

    // Update is called once per frame
    void Update()
    {
        //現在の経過時間を周期で割った余り
        float currentTime = Mathf.Repeat(Time.time - initialTime, seqTime);

        //Sin関数で周期的な動きに変換
        float x = radius * Mathf.Sin(currentTime / seqTime * 2f * Mathf.PI);
        
        //cutLenを上回っていたらcutLenにカット
        if(Mathf.Abs(x) > cutLen)
        {
            x = cutLen * Mathf.Sign(x);
        }

        //動く方向にオフセットを計算
        Vector3 offset = direcitonIndicator.forward * x;

        //初期位置にオフセットを加算
        movingTarget.position = originalPos + offset;
    }
}
