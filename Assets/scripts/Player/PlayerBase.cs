using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerBase : Damageable
{
    public float speed = 1f;
    public float invulnerabilityTime = 1f;

    private Rigidbody2D rb;
    private Vector2 movementInput;
    private BoxCollider2D boxC2d;
    private SpriteRenderer spriteRenderer;

    private void Awake()
    {
        rb = GetComponent<Rigidbody2D>();
        boxC2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void FixedUpdate()
    {
        rb.velocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        movementInput = inputValue.Get<Vector2>(); 
    }

    public override void OnHpLoss()
    {
        BlinckSprite();
        InvulnerabilityCooldown();
    }

    private IEnumerator InvulnerabilityCooldown()
    {
        print("c merman");
        boxC2d.enabled = false;

        yield return new WaitForSeconds(invulnerabilityTime);
        boxC2d.enabled = true;
    }

    private IEnumerator BlinckSprite()
    {
        for (int i = 0; i < 5; i++)
        {
            spriteRenderer.color = new Color(0, 0, 0, 0);
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = new Color(0, 0, 0, 1);
            yield return new WaitForSeconds(0.1f);
        }
    }
}
