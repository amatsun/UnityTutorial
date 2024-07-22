using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HitReaction : MonoBehaviour
{
    [SerializeField]
    Animator animator;
    [SerializeField]
    List<string> reactionTriggers = new List<string>();
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    public void CallHitReaction()
    {
        string trigger = reactionTriggers[Random.Range(0, reactionTriggers.Count)];
        animator.SetTrigger(trigger);
    }
}
