using UnityEngine;
using TMPro;

public class PlacarVidas : MonoBehaviour
{
    public TextMeshProUGUI placarText;

    void Update()
    {
        if (GameControl.instance == null || placarText == null)
        {
            return;
        }

        placarText.text = "Pontos=" + GameControl.instance.pontuacao + " Vidas=" + GameControl.instance.vidas;
    }
}