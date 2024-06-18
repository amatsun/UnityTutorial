using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GenAndDelObject : MonoBehaviour
{
    [SerializeField]
    GameObject objectPrefab;
    List<GameObject> objects;
    float lastTime;
    int cnt;
    [SerializeField, Range(1f, 10f)]
    float duration = 1.0f;
    // Start is called before the first frame update
    void Start()
    {
        objects = new List<GameObject>();
        lastTime = Time.time;
        cnt = 0;
    }

    // Update is called once per frame
    void Update()
    {
        float currentDuration = Time.time - lastTime;
        if(currentDuration < duration)
        {
            return;
        }
        GameObject tmpObj = null;
        switch (cnt)
        {
            case 0:
            case 1:
            case 2:
            case 3:
                tmpObj = Instantiate(objectPrefab);
                objects.Add(tmpObj);
                cnt++;
                break;
            case 4:
            case 5:
            case 6:
                Destroy(objects[objects.Count - 1]);
                objects.RemoveAt(objects.Count - 1);
                cnt++;
                break;
            case 7:
                cnt = 0;
                break;
        }
        lastTime = Time.time;
    }
}
