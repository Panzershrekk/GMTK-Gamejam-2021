using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public float maxHitpoint = 100;
    public float currentHealth = 100;

    void TakeDamage(float value)
    {
        Debug.Log("Ouch boat");
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            Debug.Log("Victory");
        }
        gameManager?.RefreshUI();
    }
    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.GetComponent<Hazard>() != null)
        {
            Hazard hazard = col.GetComponent<Hazard>();
            hazard.Trigger();
            TakeDamage(hazard.DamageTakenValue);
        }
    }
}