using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float HealthRestoreValue;

    public void Trigger()
    {
        Debug.Log("eee");
        Destroy(gameObject);
    }
}
