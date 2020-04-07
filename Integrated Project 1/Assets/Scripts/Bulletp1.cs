using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bulletp1 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    void Start()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player2 player2 = hitInfo.GetComponent<Player2>();
        if (player2 != null)
        {
            player2.TakeDamage(damage);
        }
        Destroy(gameObject);
    }
}
