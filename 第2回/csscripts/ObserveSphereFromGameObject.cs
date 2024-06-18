using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ObserveSphereFromGameObject : MonoBehaviour
{
    [SerializeField]
    GameObject sphere;
    SphereController sphereController;
    // Start is called before the first frame update
    void Start()
    {
        sphereController = sphere.GetComponent<SphereController>();
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log($"Sphere elapsed time: {sphereController.time}, current radius: {sphereController.GetCurrentRadius()}");
    }
}
