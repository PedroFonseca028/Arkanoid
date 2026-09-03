using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsParaDestruir = 1;
    public bool indestrutivel = false;
    public int pontos = 10; // Quanto esse bloco vale ao ser destruído

    private int hitsRestantes;
    private bool jaDestruido = false; // trava contra chamadas múltiplas no mesmo frame

    void Start()
    {
        hitsRestantes = hitsParaDestruir;
    }

    public void ApanharGolpe()
    {
        if (indestrutivel || jaDestruido)
        {
            return;
        }

        hitsRestantes--;

        if (hitsRestantes <= 0)
        {
            jaDestruido = true;

            GerarNovasBolas gerador = GetComponent<GerarNovasBolas>();

            if (GameControl.instance != null)
            {
                GameControl.instance.AdicionarPontuacao(pontos);
            }

            // Destroi o bloco ANTES de gerar as bolas, garantindo que ele
            // sempre morra mesmo que algo dê erro na geração
            Destroy(gameObject);

            if (LevelManager.instance != null)
            {
                LevelManager.instance.NotificarBlocoDestruido();
            }

            if (gerador != null)
            {
                gerador.GerarBolasAoSerDestruido();
            }
        }
    }
}