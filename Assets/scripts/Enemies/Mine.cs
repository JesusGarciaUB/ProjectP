using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{

    public int damage;
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerBase>().canHit)
            {
                collision.GetComponent<Damageable>().Health = damage;
                if (collision.GetComponent<Damageable>().Health <= 0) collision.GetComponent<PlayerBase>().Death();
                Destroy(gameObject);
            }
        }
    }
}
