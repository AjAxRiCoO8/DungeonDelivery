using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
    }

    private void Update()
    {
        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;

        float moveX = rb.position.x;
        float moveY = rb.position.y;

        // Up
        if (Input.GetKey(KeyCode.W))
        {
            //tempPos.y += speed * Time.deltaTime;
            moveY += speed * Time.deltaTime;
        }

        // Down
        if (Input.GetKey(KeyCode.S))
        {
            //tempPos.y -= speed * Time.deltaTime;
            moveY -= speed * Time.deltaTime;
        }

        // Left
        if (Input.GetKey(KeyCode.A))
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            //tempPos.x -= speed * Time.deltaTime;
            moveX -= speed * Time.deltaTime;
        }

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            tempScale.x = Mathf.Abs(tempScale.x) * -1;
            //tempPos.x += speed * Time.deltaTime;
            moveX += speed * Time.deltaTime;
        }

        rb.MovePosition(new Vector2(moveX, moveY));
        //transform.position = tempPos;
        transform.localScale = tempScale;
    }
}
