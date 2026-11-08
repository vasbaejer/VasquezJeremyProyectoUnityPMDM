using UnityEngine;

public class MusicaPersistente : MonoBehaviour
{
    private static MusicaPersistente instancia;

    private void Awake()
    {
        if (instancia != null && instancia != this)
        {
            Debug.Log("Musica duplicada. Destruyendo copia.");
            Destroy(gameObject);
            return;
        }

        instancia = this;

        DontDestroyOnLoad(gameObject);

        Debug.Log("Musica protegida entre escenas.");
    }
}

