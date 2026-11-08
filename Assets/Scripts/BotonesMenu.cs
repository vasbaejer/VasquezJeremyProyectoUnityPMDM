using UnityEngine;
using UnityEngine.SceneManagement;


public class BotonesMenu : MonoBehaviour
{
    public void IniciarJuego()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex + 1);
    }

    public void Salir()
    {
        Application.Quit();
    }
}