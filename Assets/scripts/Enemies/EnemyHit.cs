using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Damageable
{
    private int damageReceived;
    private bool ticking;
    private Color og;
    private Color oga;
    private Animator anim;
    public GameObject deathSound;
    private GameObject cosa;

    private void Start()
    {
        anim = GetComponent<Animator>();
        og = GetComponent<SpriteRenderer>().color;
        oga = og;
        oga.a = 0.5f;
        ticking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            if (Health > 0)
            {
                Destroy(collision.gameObject);
                damageReceived = GlobalVariables.Instance.player.GetComponent<Damageable>().Damage;
                Health = damageReceived;
                if (Health <= 0) Death();
            }
        }
    }

    private void Death()
    {
        cosa = Instantiate(deathSound);
        if (GetComponent<EnemyShoot>() != null) GlobalVariables.Instance.Score = 2500;
        else GlobalVariables.Instance.Score = 1000;
        anim.SetTrigger("die");
        print(GlobalVariables.Instance.Score);
    }

    private void DestroyShip()
    {
        Destroy(cosa, 5f);
        Destroy(gameObject);
    }
    public override void OnHpLoss()
    {
        if (!ticking) StartCoroutine(tick());
    }

    private IEnumerator tick()
    {
        ticking = true;
        SpriteRenderer sr = GetComponent<SpriteRenderer>();
        sr.color = oga; 
        yield return new WaitForSeconds(0.15f);
        sr.color = og;
        ticking = false;
    }
}
