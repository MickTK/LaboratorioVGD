using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapLocator : MonoBehaviour
{
    public GameObject currentMap;
    public GameObject nextMap;

    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
    void OnTriggerEnter(Collider other)
    {
        if (other.CompareTag("Player"))
        {
            nextMap.transform.position = new Vector3(currentMap.transform.position.x - 200,0,0);
        }
    }
}
