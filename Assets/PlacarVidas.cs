using UnityEngine;
using TMPro;

public class PlacarVidas : MonoBehaviour
{
    public TextMeshProUGUI vidasText;

    void Update()
    {
        // Só atualiza o texto se tudo já estiver pronto.
        // Isso evita o erro caso essa linha rode antes do GameControl existir.
        if (vidasText == null || GameControl.instance == null)
        {
            return;
        }

        vidasText.text = "Vidas: " + GameControl.instance.vidas;
    }
}