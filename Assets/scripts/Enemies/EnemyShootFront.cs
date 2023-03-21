using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootFront : MonoBehaviour
{
    private bool CanShoot;
    public float Cooldown;
    public GameObject bullet;
    private int damage;

    private void Start()
    {
        StartCoroutine(StartCooldown());
        damage = GetComponent<Damageable>().Damage;
    }

    private void FixedUpdate()
    {
        if (GlobalVariables.Instance.canShoot)
        {
            if (CanShoot)
            {
                Shoot();
                StartCoroutine(StartCooldown());
            }
        }
    }
    private void Shoot()
    {
        Vector3 shootPoint = transform.position;
        shootPoint.y -= 0.16f;
        GameObject aux = Instantiate(bullet, shootPoint, Quaternion.identity);
        aux.GetComponent<Bullet>().GiveSelf = transform.position;
        aux.GetComponent<Bullet>().GiveDamage = damage;
        aux.GetComponent<Bullet>().ShootFrontal();
    }
    private IEnumerator StartCooldown()
    {
        CanShoot = false;
        yield return new WaitForSeconds(Cooldown);
        CanShoot = true;
    }
}
