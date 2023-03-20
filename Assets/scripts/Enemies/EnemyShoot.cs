using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot :  MonoBehaviour
{
    public float offsetArc;
    private List<Transform> cannons;
    public GameObject bullet;
    public float Cooldown;
    private bool CanShoot;
    private bool InRange;
    private float ShootArc;
    private GameObject player;
    private int damage;
    private void Start()
    {
        damage = GetComponent<Damageable>().Damage;
        player = GameObject.FindGameObjectWithTag("Player");
        CanShoot = true;
        float height = GetComponent<SpriteRenderer>().size.y / 2;
        ShootArc = height + offsetArc;
    }
    private void FixedUpdate()
    {
        if (transform.position.y + ShootArc < player.transform.position.y && transform.position.y - ShootArc > player.transform.position.y) InRange = true;
        else InRange = false;

        if (InRange && CanShoot)
        {
            Shoot();
            StartCoroutine(StartCooldown());
        }
    }

    private void Shoot()
    {
        for (int x = 0; x < cannons.Count; x++) {
            GameObject aux = Instantiate(bullet, cannons[x].transform.position, Quaternion.identity);
            aux.GetComponent<Bullet>().GiveSelf = transform.position;
            aux.GetComponent<Bullet>().GiveDamage = damage;
        }
    }
    private IEnumerator StartCooldown()
    {
        CanShoot = false;
        yield return new WaitForSeconds(Cooldown);
        CanShoot = true;
    }
}
