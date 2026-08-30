using UnityEngine;
using TMPro;

public class PlacarVidas : MonoBehaviour
{
    public TextMeshProUGUI vidasText;

    void Update()
    {
        vidasText.text = "Vidas: " + GameControl.instance.vidas;
    }
}