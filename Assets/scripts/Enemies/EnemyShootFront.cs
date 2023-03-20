using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemyShootFront : MonoBehaviour
{
    private bool CanShoot;
    public float Cooldown;
    public GameObject bullet;

    private void Start()
    {
        CanShoot = true;
    }
    private void Shoot()
    {
        Vector3 shootPoint = transform.position;
        shootPoint.y -= 0.16f;
        Instantiate(bullet, shootPoint, Quaternion.identity);
    }
    private IEnumerator StartCooldown()
    {
        CanShoot = false;
        yield return new WaitForSeconds(Cooldown);
        CanShoot = true;
    }
}
