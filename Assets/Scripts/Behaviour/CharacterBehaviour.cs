using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public GameManager gameManager;
    public float maxHitpoint = 100;
    public float currentHealth = 100;

    // Start is called before the first frame update
    void Start()
    {

    }

    // Update is called once per frame
    void Update()
    {

    }

    void TakeDamage(float value)
    {
        currentHealth -= value;
        if (currentHealth <= 0)
        {
            Debug.Log("Game over");
        }
        gameManager?.RefreshUI();
    }

    void RestoreHealth(float value)
    {
        currentHealth += value;
        if (currentHealth > maxHitpoint)
        {
            currentHealth = maxHitpoint;
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
        if (col.GetComponent<Fish>() != null)
        {
            Fish fish = col.GetComponent<Fish>();
            fish.Trigger();
            RestoreHealth(fish.HealthRestoreValue);
        }
    }
}
