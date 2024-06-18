using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ComponentAttacher : MonoBehaviour
{
    [SerializeField]
    GameObject targetSphere;
    [SerializeField]
    float initialDeltaT = 0.003f;
    [SerializeField]
    float initialMaxHeight = 10f;
    // Start is called before the first frame update
    void Start()
    {
        SphereVerticalMover mover = targetSphere.AddComponent<SphereVerticalMover>();
        mover.deltaT = initialDeltaT;
        mover.maxHeight = initialMaxHeight;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
