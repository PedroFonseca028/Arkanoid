using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public int vidas = 3;

    void Awake()
    {
        instance = this;
    }

    public void PerderVida()
    {
        vidas--;
        Debug.Log("Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            Debug.Log("Game Over!");
            // depois vamos trocar isso por SceneManager.LoadScene("Cena_Final");
        }
    }
}