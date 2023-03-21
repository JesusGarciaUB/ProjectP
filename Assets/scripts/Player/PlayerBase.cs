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
    private Color og;
    private Color oga;
    private Animator anim;
    private bool canMove;
    private void Awake()
    {
        canMove = true;
        anim = GetComponent<Animator>();
        rb = GetComponent<Rigidbody2D>();
        boxC2d = GetComponent<BoxCollider2D>();
        spriteRenderer = GetComponent<SpriteRenderer>();
        og = spriteRenderer.color;
        oga = og;
        oga.a = 0.5f;
    }

    private void FixedUpdate()
    {
        if (canMove) rb.velocity = movementInput * speed;
    }

    private void OnMove(InputValue inputValue)
    {
        if(canMove) movementInput = inputValue.Get<Vector2>(); 
    }

    private void LockMovement()
    {
        canMove = false;
    }
    public void Death()
    {
        anim.SetTrigger("die");
    }
    private void DestroyShip()
    {
        Destroy(gameObject);
    }
    public override void OnHpLoss()
    {
        StartCoroutine(BlinckSprite());
        StartCoroutine(InvulnerabilityCooldown());
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
            spriteRenderer.color = oga;
            yield return new WaitForSeconds(0.1f);
            spriteRenderer.color = og;
            yield return new WaitForSeconds(0.1f);
        }
    }
}
