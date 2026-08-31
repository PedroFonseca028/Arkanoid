using UnityEngine;

public class Brick : MonoBehaviour
{
    public int hitsParaDestruir = 1;   // Quantas vezes a bola precisa bater
    public bool indestrutivel = false; // Se marcado, o bloco nunca é destruído

    private int hitsRestantes;

    void Start()
    {
        hitsRestantes = hitsParaDestruir;
    }

    // Chamado pelo script da bola toda vez que ela colide com este bloco
    public void ApanharGolpe()
    {
        if (indestrutivel)
        {
            return; // não faz nada, o bloco fica intacto
        }

        hitsRestantes--;

        if (hitsRestantes <= 0)
        {
            Destroy(gameObject);
        }
    }
}