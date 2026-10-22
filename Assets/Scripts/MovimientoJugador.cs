using System;
using UnityEngine;
using UnityEngine.InputSystem;

public class MovimientoJugador : MonoBehaviour
{
    InputAction moveAction;
    InputAction jumpAction;
    Rigidbody2D rigid2D;
    BoxCollider2D boxColl2D;

    [SerializeField]
    float velocidad = 3f;

    [SerializeField]
    float velocidadSalto = 5f;

    void Start()
    {
        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");

        rigid2D = GetComponent<Rigidbody2D>();
        boxColl2D = GetComponent<BoxCollider2D>();
    }

    void Update()
    {

        Vector2 movimiento = moveAction.ReadValue<Vector2>();

        transform.Translate(
         movimiento.x * velocidad * Time.deltaTime,
         movimiento.y * velocidad * Time.deltaTime, 0
         );

        if (jumpAction.IsPressed())
        {
            rigid2D.linearVelocityY = velocidadSalto;
        }
    }
}
