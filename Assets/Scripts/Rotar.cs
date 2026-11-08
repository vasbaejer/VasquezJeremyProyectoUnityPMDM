using UnityEngine;


public class Rotar : MonoBehaviour
{
    [SerializeField] private float velocidadGiro = 180f;

    void Update()
    {
        transform.Rotate(0f, 0f, velocidadGiro * Time.deltaTime);
    }
}
