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
    public float projectileSeparation = 0.2f;

    public void OnFire()
    {
        if (canShoot)
        {
            StartCoroutine(ShootingCooldown());
            Vector3 playerPos = transform.position;
            if (numberOfProjectiles % 2 == 0)
            {
                for (int i = 0; i < numberOfProjectiles/2; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, playerPos, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                    playerPos.y += projectileSeparation;
                }

                for (int i = 0; i < numberOfProjectiles / 2; i++)
                {
                    GameObject bullet = Instantiate(bulletPrefab, transform.position, Quaternion.identity);
                    Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
                    rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                    playerPos.y -= projectileSeparation;
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
