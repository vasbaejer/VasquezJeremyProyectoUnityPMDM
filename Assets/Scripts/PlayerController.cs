using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerController : MonoBehaviour
{
    [SerializeField] private float velocidad = 3f;
    [SerializeField] private float fuerzaSalto = 6f;
    [SerializeField] private LayerMask suelo;
    [SerializeField] private AudioSource audioSalto;

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private Animator animator;
    private SpriteRenderer sprite;

    private InputAction moveAction;
    private InputAction jumpAction;

    private float dirX;

    private enum EstadoAnimacion { parado, corriendo, saltando, cayendo }

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
        sprite = GetComponent<SpriteRenderer>();

        moveAction = InputSystem.actions.FindAction("Move");
        jumpAction = InputSystem.actions.FindAction("Jump");
    }

    void Update()
    {
        //entrada y animamos
        dirX = moveAction.ReadValue<Vector2>().x;
        if (jumpAction.WasPressedThisFrame()) Debug.Log("Salto pulsado. En suelo: " + EstaEnSuelo());

        if (jumpAction.WasPressedThisFrame() && EstaEnSuelo())
        {
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaSalto);
            audioSalto.Play();
        }

        ActualizarAnimacion();
    }

    void FixedUpdate()
    {
        rb.linearVelocity = new Vector2(dirX * velocidad, rb.linearVelocity.y);
    }

    private bool EstaEnSuelo()
    {
        return Physics2D.BoxCast(coll.bounds.center, coll.bounds.size, 0f, Vector2.down, .1f, suelo);
    }

    private void ActualizarAnimacion()
    {
        EstadoAnimacion estado;

        if (dirX != 0f)
        {
            estado = EstadoAnimacion.corriendo;
            sprite.flipX = dirX < 0f;
        }
        else
        {
            estado = EstadoAnimacion.parado;
        }

        if (rb.linearVelocity.y > .1f)
        {
            estado = EstadoAnimacion.saltando;
        }
        else if (rb.linearVelocity.y < -.1f)
        {
            estado = EstadoAnimacion.cayendo;
        }

        animator.SetInteger("estado", (int)estado);
    }
}