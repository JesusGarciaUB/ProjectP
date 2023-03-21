using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerShoot : MonoBehaviour
{
    public enum Direction { UP, LEFT, RIGHT }


    public GameObject bulletPrefab;
    public float bulletForce = 20f;
    public float shootCooldown = 0.5f;
    public int numberOfFrontalProjectiles = 2;
    public int numberOfLateralProjectiles = 3;
    public float projectileSeparation = 0.15f;
    public float projectileLateralSeparation = 0.2f;
    public float topOffset = 0.2f; //Set bullet position on top of the ship
    public float leftOffset = 0.15f; //Set bullet position on lateral of the ship
    public Direction dir = Direction.UP;
    private bool CanShoot;

    private void Awake()
    {
        CanShoot = true;
    }

    private void LockShoot() {
        CanShoot = false;
    }

    public void OnFireLeft()
    {
        if (CanShoot)
        {
            Vector3 playerPos1 = transform.position;
            playerPos1.x -= leftOffset;
            Vector3 playerPos2 = playerPos1;
            dir = Direction.LEFT;
            Shoot(playerPos1, playerPos2, numberOfLateralProjectiles);
        }
    }

    public void OnFireRight()
    {
        if (CanShoot)
        {
            Vector3 playerPos1 = transform.position;
            playerPos1.x += leftOffset;
            Vector3 playerPos2 = playerPos1;
            dir = Direction.RIGHT;
            Shoot(playerPos1, playerPos2, numberOfLateralProjectiles);
        }
    }

    public void OnFire()
    {
        if (CanShoot)
        {
            Vector3 playerPos1 = transform.position;
            playerPos1.y += topOffset;
            Vector3 playerPos2 = playerPos1;
            dir = Direction.UP;
            Shoot(playerPos1, playerPos2, numberOfFrontalProjectiles);
        }
    }

    private void Shoot(Vector3 playerPos1, Vector3 playerPos2,int projectileNum)
    {

        if (projectileNum % 2 == 0)
        { 
            switch (dir)
            {
                case Direction.UP:
                    ParShootingUp(playerPos1, playerPos2, projectileNum);
                    break;
                case Direction.LEFT:
                    ParShootingLeft(playerPos1, playerPos2, projectileNum);
                    break;
                case Direction.RIGHT:
                    ParShootingRight(playerPos1, playerPos2, projectileNum);
                    break;
            }
        }
        else
        {
            GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();

            switch (dir)
            {
                case Direction.UP:
                    rb.AddForce(transform.up * bulletForce, ForceMode2D.Impulse);
                    ParShootingUp(playerPos1, playerPos2, projectileNum - 1);
                    break;
                case Direction.LEFT:
                    rb.AddForce((transform.right * -1) * bulletForce, ForceMode2D.Impulse);
                    ParShootingLeft(playerPos1, playerPos2, projectileNum - 1);
                    break;
                case Direction.RIGHT:
                    rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
                    ParShootingRight(playerPos1, playerPos2, projectileNum - 1);
                    break;
            }
        }
    }

    private void ParShootingUp(Vector3 playerPos1, Vector3 playerPos2, int projectilNum)
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

    private void ParShootingLeft(Vector3 playerPos1, Vector3 playerPos2, int projectilNum)
    {
        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos1.y += projectileLateralSeparation;
            else playerPos1.y += projectileLateralSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((transform.right * -1) * bulletForce, ForceMode2D.Impulse);
        }

        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos2.y -= projectileLateralSeparation;
            else playerPos2.y -= projectileLateralSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos2, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce((transform.right * -1) * bulletForce, ForceMode2D.Impulse);
        }
    }

    private void ParShootingRight(Vector3 playerPos1, Vector3 playerPos2, int projectilNum)
    {
        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos1.y += projectileLateralSeparation;
            else playerPos1.y += projectileLateralSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos1, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        }

        for (int i = 0; i < projectilNum / 2; i++)
        {
            if (i != 0) playerPos2.y -= projectileLateralSeparation;
            else playerPos2.y -= projectileLateralSeparation / 2;

            GameObject bullet = Instantiate(bulletPrefab, playerPos2, Quaternion.identity);
            Rigidbody2D rb = bullet.GetComponent<Rigidbody2D>();
            rb.AddForce(transform.right * bulletForce, ForceMode2D.Impulse);
        }
    }

    /*private IEnumerator ShootingCooldown()
    {
        canShoot = false;
        yield return new WaitForSeconds(shootCooldown);
        canShoot = true;
    }*/
}
