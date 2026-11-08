using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;

public class PlayerItems : MonoBehaviour
{
    [SerializeField] private Text textoFrutas;
    [SerializeField] private AudioSource sonidoFruta;

    private int frutas = 0;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.CompareTag("Fruta"))
        {
            Destroy(collision.gameObject);
            frutas++;
            textoFrutas.text = "Frutas: " + frutas;
            sonidoFruta.Play();
        }
        else if (collision.gameObject.CompareTag("Meta"))
        {
            SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
        }
    }
}