using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveSphere : MonoBehaviour
{
    [SerializeField]
    SphereController sphereController;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Sphere elapsed time: {sphereController.time}, current radius: {sphereController.GetCurrentRadius()}");
    }
}
