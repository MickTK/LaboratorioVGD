using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MoneyValue : MonoBehaviour
{
    private int value;
    public GameVariable gameVariable;
    public int Value { get => value * gameVariable.duplicatoreMonete; set => this.value = value; }
}
