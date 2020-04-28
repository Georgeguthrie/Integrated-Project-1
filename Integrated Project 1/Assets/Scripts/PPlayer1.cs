﻿using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

class PPlayer1 : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.A;
    public KeyCode moveRightKey = KeyCode.D;
    public KeyCode JumpKey = KeyCode.W;
    public KeyCode Block = KeyCode.E;
    bool canjump = false;
    float direction = 0.0f;
    public float speed = 0.2f;
    public int health = 100;
    public Animator animator;
    bool blocking = false;
    private Renderer rend;
    public Color damage1 = Color.white;

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
        bool isBlockPressed = Input.GetKey(Block);

        if (isLeftPressed)
        {
            direction = -1.0f;
            animator.SetBool("IsPWalk", true);
        }
        else if (isRightPressed)
        {
            direction = 1.0f;
            animator.SetBool("IsPWalk", true);
        }
        else
        {
            direction = 0.0f;
            animator.SetBool("IsPWalk", false);
        }
        if (isJumpPressed && canjump)
        {
            animator.SetBool("IsPJump", true);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 400);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(1.5f);
                animator.SetBool("IsPJump", false);
            }
        }
        if (isBlockPressed)
        {
            blocking = true;
            animator.SetBool("IsPBlock", true);
        }
        else
        {
            blocking = false;
            animator.SetBool("IsPBlock", false);
        }
    }

    public void OnCollisionEnter2D(Collision2D other)
    {
        switch (other.gameObject.name)
        {
            case "Bottom Wall":
                canjump = true;
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
        }
    }
    public void TakeDamage(int damage)
    {
        if (blocking == false)
        {
            health -= damage;

            if (health <= 0)
            {
                SceneManager.LoadScene("Game Over p2");
            }
            if (health <= 50)
            {
                rend = GetComponent<Renderer>();
                rend.material.color = damage1;
            }
        }
    }
}