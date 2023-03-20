using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShoot :  MonoBehaviour
{
    public List<Transform> cannons;
    public GameObject bullet;
    public float Cooldown;
    private bool CanShoot;
    private int damage;
    private bool entered;
    private void Start()
    {
        entered = false;
        damage = GetComponent<Damageable>().Damage;
        CanShoot = true;
    }

    private void FixedUpdate()
    {
        if (GetComponent<EnemyBase>().GetState != 0) entered = true;
        if (CanShoot && entered)
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
