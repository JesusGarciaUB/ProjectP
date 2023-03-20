using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float shootCooldown = 0.5f;
    public int numberOfFrontalProjectiles = 2;
    public int numberOfLateralProjectiles = 3;
    public float projectileSeparation = 0.15f;
    private float topOffset = 0.15f; //Set bullet position on top of the ship
    private float leftOffset = 0.15f; //Set bullet position on lateral of the ship


    public void onFireLeft()
    {
        print("Left");
        Vector3 playerPos1 = transform.position;
        playerPos1.x -= leftOffset;
        Vector3 playerPos2 = playerPos1;
        Shoot(playerPos1, playerPos2, numberOfLateralProjectiles);
    }

    public void onFireRight()
    {
        print("Right");
        Vector3 playerPos1 = transform.position;
        playerPos1.x += leftOffset;
        Vector3 playerPos2 = playerPos1;
        Shoot(playerPos1, playerPos2, numberOfLateralProjectiles);
    }

    public void OnFire()
    {
        Vector3 playerPos1 = transform.position;
        playerPos1.y += topOffset;
        Vector3 playerPos2 = playerPos1;
        Shoot(playerPos1, playerPos2, numberOfFrontalProjectiles);
    }

    private void Shoot(Vector3 playerPos1, Vector3 playerPos2,int projectileNum)
    {

        if (projectileNum % 2 == 0)
        {
            ParShooting(playerPos1, playerPos2, projectileNum);
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);

            ParShooting(playerPos1, playerPos2, projectileNum - 1);
        }
    }

    private void ParShooting(Vector3 playerPos1, Vector3 playerPos2, int projectilNum)
    {
        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos1.x += projectileSeparation;
            else playerPos1.x += projectileSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }

        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos2.x -= projectileSeparation;
            else playerPos2.x -= projectileSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos2, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
        }
    }

    /*private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }*/
}
