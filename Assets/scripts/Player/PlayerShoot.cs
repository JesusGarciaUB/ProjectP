using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public bool canShoot = true;
    public float shootCooldown = 0.5f;
    public int numberOfProjectiles = 2;
    public float projectileSeparation = 0.15f;

    public void OnFire()
    {
        if (canShoot)
        {
            //StartCoroutine(ShootingCooldown());
            Vector3 playerPos1 = transform.position;
            Vector3 playerPos2 = transform.position;
            if (numberOfProjectiles % 2 == 0)
            {
                for (int i = 0; i < numberOfProjectiles/2; i++)
                {
                    if (i != 0) playerPos1.x += projectileSeparation;
                    else playerPos1.x += projectileSeparation / 2;

                    GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                }

                for (int i = 0; i < numberOfProjectiles / 2; i++)
                {
                    if (i != 0) playerPos2.x -= projectileSeparation;
                    else playerPos2.x -= projectileSeparation / 2;

                    GameObject bullet = Instantiate(bulletPrefab, playerPos2, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                }
            }
        }
    }

    private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }
}
