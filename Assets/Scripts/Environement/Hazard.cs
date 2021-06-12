using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public float DamageTakenValue = 5;
    public bool IsSetUp = false;
    public void Trigger()
    {
        Destroy(gameObject);
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (IsSetUp == false)
        {
            if (col.GetComponent<Hazard>() != null)
            {
                col.GetComponent<Hazard>().IsSetUp = true;
                Destroy(gameObject);
            }
        }
    }
}
