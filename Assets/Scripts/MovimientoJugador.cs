using System;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{

    Animator animator;
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody2D rigid2D;
    BoxCollider2D boxColl2D;

    [SerializeField]
    float velocidad = 5f;

    [SerializeField]
    float velocidadSalto = 5f;

    int estadoAnimacion = 0;

    SpriteRenderer spriteRenderer;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rigid2D = GetComponent<Rigidbody2D>();
        boxColl2D = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        spriteRenderer = GetComponent<SpriteRenderer>();

        animator.SetInteger("estado", 0);

    }



    void Update()
    {
        moverse();
        saltar();

        if (rigid2D.linearVelocityY > 0.1f)
        {
            animator.SetInteger("estado", 2);
        }
        else if (Mathf.Abs(rigid2D.linearVelocityX) > 0.1f)
        {
            animator.SetInteger("estado", 1);
        }
        else
        {
            animator.SetInteger("estado", 0);
        }
    }



    void moverse()
    {
        Vector2 movimiento = moveAction.ReadValue<Vector2>();

        rigid2D.linearVelocityX = movimiento.x * velocidad;

        if (rigid2D.linearVelocityX < 0)
        {
            spriteRenderer.flipX = true;

        } else if (rigid2D.linearVelocityX > 0)
        {
            spriteRenderer.flipX = false;
        }

    }

    void saltar()
    {

        if (jumpAction.WasPressedThisFrame())
        {
            rigid2D.linearVelocityY = velocidadSalto;
        }
    }
}
