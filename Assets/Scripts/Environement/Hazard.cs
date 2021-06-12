using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Hazard : MonoBehaviour
{
    public Animator animator;
    public AudioSource audioSource;
    public float DamageTakenValue = 5;
    public bool IsSetUp = false;
    public void Trigger()
    {
        GetComponent<Collider2D>().enabled = false;
        audioSource.Play();
        animator.Play("HazardDestroy");
        Destroy(gameObject, 0.3f);
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
