using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OutOfView : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {
        
    }
    // L'oggetto viene eliminato quando esce dall'inquadratura
    void OnBecameInvisible()
    {
        Destroy(gameObject);
    }
}
