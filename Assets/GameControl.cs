using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public int vidas = 3;
    public int pontuacao = 0;

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
            Debug.Log("Game Over! Reiniciando...");
            SceneManager.LoadScene(SceneManager.GetActiveScene().name);
        }
    }

    public void AdicionarPontuacao(int pontos)
    {
        pontuacao += pontos;
        Debug.Log("Pontuação: " + pontuacao);
    }
}