using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BoatBehaviour : MonoBehaviour
{
    public Animator animator;
    public GameManager gameManager;
    public float maxHitpoint = 100;
    public float currentHealth = 100;

    void TakeDamage(float value)
    {
        if (gameManager.GameStarted == true)
        {
            animator.Play("Stun");
            currentHealth -= value;
            if (currentHealth <= 0)
            {
                gameManager.FinishGame(true);
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
        }
    }
}
