using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public enum Direction
{
    Down = 0,
    Up,
    Left,
    Right
}

public class PlayerControl : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb2d;
    private Direction gravity;

    void Start ()
    {
        rb2d = GetComponent<Rigidbody2D>();
        gravity = Direction.Down;
    }
	
	void Update ()
    {
		
	}

    void FixedUpdate()
    {
        if (Input.GetKeyDown(KeyCode.I))
        {
            Physics2D.gravity = new Vector2(0, Physics2D.gravity.magnitude);
            gravity = Direction.Up;
        }
        if (Input.GetKeyDown(KeyCode.K))
        {
            Physics2D.gravity = new Vector2(0, -Physics2D.gravity.magnitude);
            gravity = Direction.Down;
        }
        if (Input.GetKeyDown(KeyCode.J))
        {
            Physics2D.gravity = new Vector2(-Physics2D.gravity.magnitude, 0);
            gravity = Direction.Left;
        }
        if (Input.GetKeyDown(KeyCode.L))
        {
            Physics2D.gravity = new Vector2(Physics2D.gravity.magnitude, 0);
            gravity = Direction.Right;
        }

        float moveHorizontal = Input.GetAxis("Horizontal");
        float moveVertical = Input.GetAxis("Vertical");

        Vector2 movement;
        if (gravity == Direction.Up || gravity == Direction.Down)
        {
            movement = new Vector2(moveHorizontal, 0f);
        }
        else
        {
            movement = new Vector2(0f, moveVertical);
        }
        //Vector2 movement = new Vector2(moveHorizontal, 0f);
        transform.Translate(movement * speed*Time.deltaTime);
    }
}
