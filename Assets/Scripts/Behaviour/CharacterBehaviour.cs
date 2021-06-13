using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CharacterBehaviour : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public float maxHitpoint = 100;
    public float currentHealth = 100;

    void TakeDamage(float value)
    {
        if (gameManager.GameStarted == true)
        {
            currentHealth -= value;
            animator.Play("Stun");
            if (currentHealth <= 0)
            {
                gameManager.FinishGame();
            }
            gameManager?.RefreshUI();
        }
    }

    void RestoreHealth(float value)
    {
        if (gameManager.GameStarted == true)
        {
            currentHealth += value;
            if (currentHealth > maxHitpoint)
            {
                currentHealth = maxHitpoint;
            }
            gameManager?.RefreshUI();
        }
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (gameManager.GameStarted == true)
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
}
