using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelManager : MonoBehaviour
{
    public static LevelManager instance;

    public string proximaCena = "Level2";
    public bool ultimoNivel = false;
    public float tempoParaTransicao = 1f;

    private int blocosRestantes;
    private bool nivelConcluido = false;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        blocosRestantes = 0;

        foreach (GameObject bloco in GameObject.FindGameObjectsWithTag("Brick"))
        {
            Brick brick = bloco.GetComponent<Brick>();
            if (brick != null && !brick.indestrutivel)
            {
                blocosRestantes++;
            }
        }
    }

    public void NotificarBlocoDestruido()
    {
        blocosRestantes--;

        if (blocosRestantes <= 0 && !nivelConcluido)
        {
            nivelConcluido = true;
            Invoke(nameof(AvancarNivel), tempoParaTransicao);
        }
    }

    void AvancarNivel()
    {
        if (GameControl.instance != null)
        {
            GameControl.instance.CarregarProximoNivel(proximaCena, ultimoNivel);
        }
        else
        {
            SceneManager.LoadScene(proximaCena);
        }
    }
}
