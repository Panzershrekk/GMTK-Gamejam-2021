using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    public GameManager gameManager;
    public Animator sharkAnimator;
    public float speed = 10.0f;
    public Rigidbody2D rb;
    private Vector2 _movement;
    private Vector2 _mousePosition;

    // Update is called once per frame
    void Update()
    {
        if (gameManager.GameStarted == true && gameManager.PlayerInControl == true)
        {
            _movement.x = Input.GetAxisRaw("Horizontal");
            _movement.y = Input.GetAxisRaw("Vertical");
            if (_movement.x != 0 || _movement.y != 0)
            {
                sharkAnimator.SetBool("Moving", true);
            }
            else
            {
                sharkAnimator.SetBool("Moving", false);
            }
            Flip();
        }
    }

    void FixedUpdate()
    {
        if (gameManager.GameStarted == true && gameManager.PlayerInControl == true)
        {
            rb.MovePosition(rb.position + _movement * speed * Time.fixedDeltaTime);
        }
    }

    public void Flip()
    {
        if (_movement.x > 0)
        {
            transform.localScale = new Vector3(1, 1, 1);
        }
        else if (_movement.x < 0)
        {
            transform.localScale = new Vector3(-1, 1, 1);
        }
    }
}
