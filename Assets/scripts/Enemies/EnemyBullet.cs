using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") { 
            collision.GetComponent<Damageable>().Health = GetComponent<Bullet>().damage;
            if (collision.GetComponent<Damageable>().Health <= 0) Destroy(collision.gameObject); 
            Destroy(gameObject); 
        }
    }
}
