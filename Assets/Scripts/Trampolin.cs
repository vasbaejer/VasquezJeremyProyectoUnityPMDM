using UnityEngine;


public class Trampolin : MonoBehaviour
{
    [SerializeField] private float fuerzaRebote = 10f;
    [SerializeField] private AudioSource sonido;

    private BoxCollider2D coll;
    private Animator animator;

    void Start()
    {
        coll = GetComponent<BoxCollider2D>();
        animator = GetComponent<Animator>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (!collision.gameObject.CompareTag("Player")) return;

        bool caeEncima = collision.collider.bounds.min.y > coll.bounds.max.y - 0.1f;

        if (caeEncima)
        {
            Rigidbody2D rb = collision.gameObject.GetComponent<Rigidbody2D>();
            rb.linearVelocity = new Vector2(rb.linearVelocity.x, fuerzaRebote);

            if (animator != null) animator.SetTrigger("saltar");
            if (sonido != null) sonido.Play();
        }
    }
}
