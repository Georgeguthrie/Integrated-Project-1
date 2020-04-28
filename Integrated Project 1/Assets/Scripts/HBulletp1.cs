using System.Collections;
using System.Collections.Generic;
using System.Security.Cryptography;
using UnityEngine;

public class HBulletp1 : MonoBehaviour
{
    public float speed = 20f;
    public int damage = 10;
    public Rigidbody2D rb;
    public Sprite Sprite;
    void Update()
    {
        rb.velocity = transform.right * speed;
    }

    private void OnTriggerEnter2D(Collider2D hitInfo)
    {
        Player2P player2P = hitInfo.GetComponent<Player2P>();
        if (player2P != null)
        {
            player2P.TakeDamage(damage);
            Destroy(gameObject);
        }
        Player2 player2 = hitInfo.GetComponent<Player2>();
        if (player2 != null)
        {
            player2.TakeDamage(damage);
            Destroy(gameObject);
        }
        YPlayer2 player2Y = hitInfo.GetComponent<YPlayer2>();
        if (player2Y != null)
        {
            player2Y.TakeDamage(damage);
            Destroy(gameObject);
        }
    }
}