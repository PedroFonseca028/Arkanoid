using UnityEngine;

public class GerarNovasBolas : MonoBehaviour
{
    public GameObject bolaPrefab;
    public int quantidade = 2;

    // Chamado explicitamente pelo Brick quando o bloco é destruído por ter sido atingido
    public void GerarBolasAoSerDestruido()
    {
        if (bolaPrefab == null)
        {
            Debug.LogError("Bola Prefab não foi configurado no bloco: " + gameObject.name);
            return;
        }

        for (int i = 0; i < quantidade; i++)
        {
            GameObject novaBola = Instantiate(bolaPrefab, transform.position, Quaternion.identity);

            ballMove script = novaBola.GetComponent<ballMove>();
            if (script != null)
                script.Lancar();
            else
                Debug.LogError("O Prefab da bola não possui o script ballMove!");
        }
    }
}