using UnityEngine;

public class MovimientoLateral : MonoBehaviour
{
    [SerializeField] private float velocidad = 2f;
    [SerializeField] private float distancia = 3f; // cuanto se mueve

    private float xInicial;
    private int direccion = 1;

    void Start()
    {
        xInicial = transform.position.x;
    }

    void Update()
    {
        transform.Translate(Vector2.right * direccion * velocidad * Time.deltaTime);

        if (transform.position.x > xInicial + distancia)
        {
            direccion = -1;
        }
        else if (transform.position.x < xInicial - distancia)
        {
            direccion = 1;
        }
    }
}