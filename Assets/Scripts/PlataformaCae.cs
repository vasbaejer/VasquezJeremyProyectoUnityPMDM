using UnityEngine;

public class PlataformaCae : MonoBehaviour
{
    [SerializeField] private float tiempoAntesDeCaer = 0.4f; // segundos desde que pisas hasta que cae
    [SerializeField] private float tiempoDestruccion = 1f; // segundos que tarda en desaparecer cuando cae

    private Rigidbody2D rb;
    private BoxCollider2D coll;
    private bool activada = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        coll = GetComponent<BoxCollider2D>();
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (activada) return;
        if (!collision.gameObject.CompareTag("Player")) return;


        bool pisaEncima = collision.collider.bounds.min.y > coll.bounds.max.y - 0.1f;

        if (pisaEncima)
        {
            activada = true;
            Invoke("Caer", tiempoAntesDeCaer);
        }
    }

    private void Caer()
    {
        rb.bodyType = RigidbodyType2D.Dynamic;
        Destroy(gameObject, tiempoDestruccion);
    }
}