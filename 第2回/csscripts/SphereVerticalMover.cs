using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereVerticalMover : MonoBehaviour
{
    public float deltaT = 0.003f;    
    public float maxHeight = 10f;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpherePosition = new Vector3(0, 0, 0);
        currentSpherePosition.y = Mathf.Abs(maxHeight * Mathf.Cos(time));
        gameObject.transform.position = currentSpherePosition;
        time += deltaT;
    }
}
