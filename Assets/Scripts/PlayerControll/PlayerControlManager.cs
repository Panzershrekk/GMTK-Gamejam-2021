using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControlManager : MonoBehaviour
{
    public float speed = 10.0f;
    public Rigidbody2D rb;
    private Vector2 _movement;
    private Vector2 _mousePosition;

    // Update is called once per frame
    void Update()
    {
        _movement.x = Input.GetAxisRaw("Horizontal");
        _movement.y = Input.GetAxisRaw("Vertical");
        /*_mousePosition = Input.mousePosition;
        _mousePosition = Camera.main.ScreenToWorldPoint(_mousePosition);*/

    }

    void FixedUpdate()
    {
        rb.MovePosition(rb.position + _movement * speed * Time.fixedDeltaTime);
    }
}
