using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Wave : MonoBehaviour
{
    public bool RandomScale = false;
    public bool RandomFlip = false;
    public Animator Animator;
    // Start is called before the first frame update
    void Start()
    {
        if (RandomScale == true)
        {
            float randomScale = Random.Range(0.7f, 1.5f);
            transform.localScale = new Vector3(randomScale, randomScale, 1);
        }
        if (RandomFlip == true)
        {
            int random = Random.Range(0, 3);
            if (random == 1)
            {
                transform.localScale = new Vector3(-1, 1, 1);
            }
            else
            {
                transform.localScale = new Vector3(1, 1, 1);
            }

        }
        Animator.Play("Idle", 0, Random.Range(0.00f, 0.99f));
    }
}
