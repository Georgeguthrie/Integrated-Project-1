using UnityEngine;
using System.Collections;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class YPlayer2 : MonoBehaviour
{
    public KeyCode moveLeftKey = KeyCode.J;
    public KeyCode moveRightKey = KeyCode.L;
    public KeyCode JumpKey = KeyCode.I;
    public KeyCode Block = KeyCode.O;
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
            animator.SetBool("IsYWalk", true);
        }
        else if (isRightPressed)
        {
            direction = 1.0f;
            animator.SetBool("IsYWalk", true);
        }
        else
        {
            direction = 0.0f;
            animator.SetBool("IsYWalk", false);
        }
        if (isJumpPressed && canjump)
        {
            animator.SetBool("IsYJump", true);
            GetComponent<Rigidbody2D>().AddForce(Vector3.up * 400);
            StartCoroutine(Timer());
            IEnumerator Timer()
            {
                yield return new WaitForSeconds(1.5f);
                animator.SetBool("IsYJump", false);
            }
        }
        if (isBlockPressed)
        {
            blocking = true;
            animator.SetBool("IsYBlock", true);
        }
        else
        {
            blocking = false;
            animator.SetBool("IsYBlock", false);
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
                SceneManager.LoadScene("Game Over p1");
            }
            if (health <= 50)
            {
                rend = GetComponent<Renderer>();
                rend.material.color = damage1;
            }
        }
    }
}
