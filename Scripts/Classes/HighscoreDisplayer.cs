using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HighscoreDisplayer : MonoBehaviour
{
    // Start is called before the first frame update
    void FixedUpdate()
    {
        Text text = transform.gameObject.GetComponent<Text>();
        text.text = "HIGHSCORE: " + MenuManager.highscore.ToString();
    }
}
