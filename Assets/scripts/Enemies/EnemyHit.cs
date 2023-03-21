using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyHit : Damageable
{
    private int damageReceived;
    private bool ticking;
    private Color og;
    private Color oga;

    private void Start()
    {
        og = GetComponent<SpriteRenderer>().color;
        oga = og;
        oga.a = 0.5f;
        ticking = false;
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.tag == "Bullet")
        {
            damageReceived = GlobalVariables.Instance.player.GetComponent<Damageable>().Damage;
            Health = damageReceived;
            if (Health <= 0) Destroy(gameObject);
        }
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
