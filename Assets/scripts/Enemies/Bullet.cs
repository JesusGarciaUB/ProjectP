using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public float timeOnScreen;
    private int damage;
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
        rb = GetComponent<Rigidbody2D>();
        Vector3 playerPos = GlobalVariables.Instance.player.transform.position;
        Vector3 dir = playerPos - parent;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
    }
}
