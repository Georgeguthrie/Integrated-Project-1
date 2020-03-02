﻿using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class Player1 : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode JumpKey = KeyCode.W;
    public KeyCode punchkey = KeyCode.R;
    bool canjump = false;
    bool hitting = false;
    float direction = 0.0f;
    public float speed = 0.2f;

    void FixedUpdate()
    {
        Vector3 position = transform.localPosition;
        position.x += speed * direction;
        transform.localPosition = position;
    }

    void Update()
    {
        bool isLeftPressed = Input.GetKey(moveLeftKey);
        bool isRightPressed = Input.GetKey(moveRightKey);
        bool isJumpPressed = Input.GetKey(JumpKey);
        bool isPunchPressed = Input.GetKey(punchkey);

        if (isLeftPressed)
        {
            direction = -1.0f;
        }
        else if (isRightPressed)
        {
            direction = 1.0f;
        }
        else
        {
            direction = 0.0f;
        }
        if (isJumpPressed && canjump)
        {
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 280);
        }
        if (isPunchPressed && hitting)
        {
            SceneManager.LoadScene("Game Over p1");
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Bottom Wall":
                canjump = true;
                break;

            case "Player 2":
                hitting = true;
                break;
        }
    }
    public void OnCollisionExit2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Bottom Wall":
                canjump = false;
                break;

            case "Player 2":
                hitting = false;
                break;
        }
    }
}