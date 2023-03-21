using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyBullet : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player") {
            if (collision.GetComponent<PlayerBase>().canHit)
            {
                collision.GetComponent<Damageable>().Health = GetComponent<Bullet>().damage;
                GlobalVariables.Instance.playerHealth = collision.GetComponent<Damageable>().Health;
                if (collision.GetComponent<Damageable>().Health <= 0) collision.GetComponent<PlayerBase>().Death();
                if (collision.GetComponent<Damageable>().Health < 6) collision.GetComponent<PlayerBase>().Low();
                Destroy(gameObject);
            }
        }
    }
}
