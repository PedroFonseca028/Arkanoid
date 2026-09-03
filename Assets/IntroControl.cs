using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class IntroControl : MonoBehaviour
{
    public string proximaCena = "Level1";
    public float tempoMaximo = 6f;

    private bool avancando = false;

    void Start()
    {
        StartCoroutine(AvancarNoFinalDaCena());
    }

    void Update()
    {
        // "Aperta um botão" cobre qualquer tecla do teclado ou botão do mouse
        if (Input.anyKeyDown)
        {
            Avancar();
        }
    }

    IEnumerator AvancarNoFinalDaCena()
    {
        yield return new WaitForSeconds(tempoMaximo);
        Avancar();
    }

    void Avancar()
    {
        if (avancando)
        {
            return;
        }

        avancando = true;
        SceneManager.LoadScene(proximaCena);
    }
}
