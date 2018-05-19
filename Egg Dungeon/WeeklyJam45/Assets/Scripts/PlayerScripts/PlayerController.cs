using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

    [SerializeField]
    private float speed;

    private Rigidbody2D rb;
    private Vector2 direction;

    private void Start() {
        rb = gameObject.GetComponent<Rigidbody2D>();
    }

	// Update is called once per frame
	void Update ()
    {
        //getInput();
	}

    private void FixedUpdate() {
        Move();
    }

    public void Move()
    {
        float moveHorizontal = Input.GetAxisRaw("Horizontal");
        float moveVertical = Input.GetAxisRaw("Vertical");

        Vector3 moveVect = new Vector3(moveHorizontal, moveVertical, 0f);
        moveVect = moveVect.normalized * speed * Time.deltaTime;

        // Movement if key is pressed
        if (moveHorizontal != 0 || moveVertical != 0) {
            rb.MovePosition(transform.position + moveVect);
        }
    }

    private void getInput()
    {
        direction = Vector2.zero;

        if (Input.GetKey(KeyCode.W))
        {
            direction += Vector2.up;
        }
        if (Input.GetKey(KeyCode.S))
        {
            direction += Vector2.down;
        }
        if (Input.GetKey(KeyCode.A))
        {
            direction += Vector2.left;
        }
        if (Input.GetKey(KeyCode.D))
        {
            direction += Vector2.right;
        }

    }
}
