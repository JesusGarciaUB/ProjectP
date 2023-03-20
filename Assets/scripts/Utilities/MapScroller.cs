using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MapScroller : MonoBehaviour
{
    public float speed;
    private Rigidbody2D rb;

    private void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Vector3 auxPos = new Vector3(transform.position.x, transform.position.y - 10f);
        Vector3 dir = auxPos - transform.position;
        rb.velocity = new Vector2(dir.x, dir.y).normalized * speed;
    }

    private void FixedUpdate()
    {
        if (transform.position.y < -2.1) Destroy(gameObject);
    }
}
