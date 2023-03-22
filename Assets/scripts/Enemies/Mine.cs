using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Mine : MonoBehaviour
{
    private Animator anim;
    public int damage;

    private void Awake()
    {
        anim = GetComponent<Animator>();
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Player")
        {
            if (collision.GetComponent<PlayerBase>().canHit)
            {
                collision.GetComponent<Damageable>().Health = damage;
                if (collision.GetComponent<Damageable>().Health <= 0) collision.GetComponent<PlayerBase>().Death();
                anim.SetTrigger("explode");
            }
        }
    }

    private void DestroyMine()
    {
        Destroy(gameObject);
    }
}
