using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Spawn : MonoBehaviour
{
    public float spawnDelay = 2f;
    private float currentTime = 0f;
    public GameObject enemy;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        currentTime += Time.deltaTime;
        if (currentTime >= spawnDelay)
        {
            currentTime = 0;
            Instantiate(enemy, this.transform);
        }
    }
    
}
