using UnityEngine;
using UnityEngine.SceneManagement;

public class GameControl : MonoBehaviour
{
    public static GameControl instance;
    public int vidas = 3;
    public int pontuacao = 0;
    public bool venceu = false;

    public string primeiraFase = "Level1";
    public string cenaFinal = "EndScene";

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    public void PerderVida()
    {
        vidas--;
        Debug.Log("Vidas restantes: " + vidas);

        if (vidas <= 0)
        {
            Debug.Log("Game Over!");
            venceu = false;
            SceneManager.LoadScene(cenaFinal);
        }
    }

    public void AdicionarPontuacao(int pontos)
    {
        pontuacao += pontos;
        Debug.Log("Pontuação: " + pontuacao);
    }

    // Chamado pelo LevelManager quando todos os blocos de uma fase são destruídos
    public void CarregarProximoNivel(string nomeDaCena, bool ultimoNivel)
    {
        if (ultimoNivel)
        {
            venceu = true;
            SceneManager.LoadScene(cenaFinal);
        }
        else
        {
            SceneManager.LoadScene(nomeDaCena);
        }
    }

    public void ReiniciarJogo()
    {
        pontuacao = 0;
        vidas = 3;
        venceu = false;
        SceneManager.LoadScene(primeiraFase);
    }
}