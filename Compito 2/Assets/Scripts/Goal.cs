using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Goal : MonoBehaviour
{
    private bool isEnabled = false;
    // Start is called before the first frame update
    void Start()
    {
    }

    // Update is called once per frame
    void Update()
    {
    }

    public void Activate(){
        isEnabled = true;
        GetComponent<Renderer>().material.color = new Color(0, 1, 0, 0.5f);

    }
    void OnTriggerEnter(Collider other) {
        if (isEnabled && other.gameObject.tag == "Player") {
            SceneManager.LoadScene(0);
        }
    }
}
