using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class EndGameControl : MonoBehaviour
{
    public TextMeshProUGUI resultadoText;
    public TextMeshProUGUI pontuacaoText;

    private bool reiniciando = false;

    void Start()
    {
        bool venceu = GameControl.instance != null && GameControl.instance.venceu;
        int pontuacaoFinal = GameControl.instance != null ? GameControl.instance.pontuacao : 0;

        if (resultadoText != null)
        {
            resultadoText.text = venceu ? "Você venceu!" : "Você perdeu!";
        }

        if (pontuacaoText != null)
        {
            pontuacaoText.text = "Pontuação final: " + pontuacaoFinal;
        }
    }

    void Update()
    {
        if (Input.anyKeyDown)
        {
            Reiniciar();
        }
    }

    void Reiniciar()
    {
        if (reiniciando)
        {
            return;
        }

        reiniciando = true;

        if (GameControl.instance != null)
        {
            GameControl.instance.ReiniciarJogo();
        }
        else
        {
            SceneManager.LoadScene("Level1");
        }
    }
}
