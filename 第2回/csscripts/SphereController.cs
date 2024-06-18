using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SphereController : MonoBehaviour
{
    [SerializeField]
    GameObject sphereObject;
    [SerializeField, Range(0f, 10f)]
    float deltaT = 0.003f;
    [SerializeField]
    float radius = 10f;
    public float time;
    // Start is called before the first frame update
    void Start()
    {
        time = 0f;
    }

    // Update is called once per frame
    void Update()
    {
        Vector3 currentSpherePosition = new Vector3 (0, 0, 0);
        currentSpherePosition.x = radius * Mathf.Cos(time);
        currentSpherePosition.z = radius * Mathf.Sin(time);
        sphereObject.transform.position = currentSpherePosition;
        time += deltaT;
    }
    public void RandomChangeRadius()
    {
        var changedRad = Random.Range(0.1f, 10f);
        radius = changedRad;
    }
    public float GetCurrentRadius()
    {
        return radius;
    }
}
