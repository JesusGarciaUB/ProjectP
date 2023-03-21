using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeOnScreen;
    public int damage;
    public float speed;
    private Vector3 parent;
    private Rigidbody2D rb;

    public int GiveDamage
    {
        set { damage = value; }
    }
    public Vector3 GiveSelf
    {
        set { parent = value; }
    }
    private void Start()
    {
        Destroy(gameObject, timeOnScreen);
    }

    public void ShootLateral(float dispersion)
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 playerPos = GlobalVariables.Instance.player.transform.position;
        playerPos.y += dispersion;
        Vector3 dir = playerPos - parent;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
    }

    public void ShootFrontal()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 auxDir = new Vector3(parent.x + Random.Range(-0.3f, 0.3f), parent.y - 1f);
        Vector3 dir = auxDir - parent;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
    }
}
