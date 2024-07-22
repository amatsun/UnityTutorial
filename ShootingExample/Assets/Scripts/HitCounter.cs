using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class HitCounter : MonoBehaviour
{
    [SerializeField]
    TextMeshProUGUI text;
    [SerializeField]
    HitReaction hitReaction;
    int hitCnt;
    // Start is called before the first frame update
    void Start()
    {
        text.text = "";
    }

    // Update is called once per frame
    void Update()
    {        
    }
    public void AddCnt()
    {
        hitCnt++;
        text.text = $"{hitCnt} Hit!";
        hitReaction.CallHitReaction();
    }
}
