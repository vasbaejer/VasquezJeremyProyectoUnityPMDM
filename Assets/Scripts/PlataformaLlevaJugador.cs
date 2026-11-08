
using UnityEngine;

public class PlataformaLlevaJugador : MonoBehaviour
{
    [SerializeField] private float velocidad = 1.5f;
    [SerializeField] private float distancia = 4f;

    private Vector3 posicionInicial;
    private bool haciaDerecha = true;

    private void Start()
    {
        posicionInicial = transform.position;
    }

    private void Update()
    {
        float movimiento = Mathf.PingPong(
            Time.time * velocidad,
            distancia * 2
        ) - distancia;

        transform.position = posicionInicial + Vector3.right * movimiento;
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(transform);
        }
    }

    private void OnCollisionExit2D(Collision2D collision)
    {
        if (collision.gameObject.CompareTag("Player"))
        {
            collision.transform.SetParent(null);
        }
    }
}
