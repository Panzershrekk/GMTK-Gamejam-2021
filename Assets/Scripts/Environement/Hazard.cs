using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float DamageTakenValue = 5;
    public void Trigger()
    {
        Destroy(gameObject);
    }
}
