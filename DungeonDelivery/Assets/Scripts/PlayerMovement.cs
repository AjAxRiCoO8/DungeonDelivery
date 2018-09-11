using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMovement : MonoBehaviour {

    [SerializeField]
    private float speed = 5;

    private void Update()
    {
        Vector3 tempPos = transform.position;
        Vector3 tempScale = transform.localScale;

        // Up
        if (Input.GetKey(KeyCode.W))
        {
            tempPos.y += speed * Time.deltaTime;
        }

        // Down
        if (Input.GetKey(KeyCode.S))
        {
            tempPos.y -= speed * Time.deltaTime;
        }

        // Left
        if (Input.GetKey(KeyCode.A))
        {
            tempScale.x = Mathf.Abs(tempScale.x);
            tempPos.x -= speed * Time.deltaTime;
        }

        // Right
        if (Input.GetKey(KeyCode.D))
        {
            tempScale.x = Mathf.Abs(tempScale.x) * -1;
            tempPos.x += speed * Time.deltaTime;
        }

        transform.position = tempPos;
        transform.localScale = tempScale;
    }
}
