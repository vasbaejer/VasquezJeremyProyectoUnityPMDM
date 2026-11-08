using UnityEngine;
using UnityEngine.SceneManagement;

public class PlayerMuerte : MonoBehaviour
{
    [SerializeField] private float alturaMinima = -10f; // por debajo de esta Y se considera caida al vacio

    private Rigidbody2D rb;
    private Animator animator;
    private bool muerto = false;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        animator = GetComponent<Animator>();
    }

    void Update()
    {
        if (transform.position.y < alturaMinima)
        {
            Morir();
        }
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Trampa"))
        {
            Morir();
        }
    }

    private void Morir()
    {
        if (muerto) return;
        muerto = true;

        rb.bodyType = RigidbodyType2D.Static;
        GetComponent<PlayerController>().enabled = false;
        animator.SetTrigger("muerte");

        Invoke("ReiniciarNivel", 1f); // espera 1 segundo para ver la animacion
    }

    private void ReiniciarNivel()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }
}
