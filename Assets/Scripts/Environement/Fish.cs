using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Fish : MonoBehaviour
{
    public float HealthRestoreValue;
    public Transform baseParent;
    public Animator destroyFishAnimator;
    public AudioSource audioSource;


    public void Trigger()
    {
        GetComponent<Collider2D>().enabled = false;
        audioSource.Play();
        destroyFishAnimator.Play("FishDestroy");
        Destroy(baseParent.gameObject, 0.5f);
    }
}
