using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ObjectList : MonoBehaviour
{
    [SerializeField]
    private Sprite sprite;
    private int time;

    public void SetSprite(Sprite sprite, int time)
    {
        this.sprite = sprite;
        this.time = time;
    }
}
