using UnityEngine;

public class GerarNovasBolas : MonoBehaviour
{
    public GameObject bolaPrefab;
    public int quantidade = 2;

    private bool jogoEncerrando = false;

    private void OnApplicationQuit()
    {
        jogoEncerrando = true;
    }

    private void OnDestroy()
    {
        // Não executa se o jogo estiver encerrando
        if (jogoEncerrando)
            return;

        // Não executa fora do Play Mode
        if (!Application.isPlaying)
            return;

        // Verifica se o prefab foi configurado
        if (bolaPrefab == null)
        {
            Debug.LogError(
                "Bola Prefab não foi configurado no bloco: "
                + gameObject.name
            );

            return;
        }

        // Cria as novas bolas
        for (int i = 0; i < quantidade; i++)
        {
            GameObject novaBola = Instantiate(
                bolaPrefab,
                transform.position,
                Quaternion.identity
            );

            // Procura o script de movimento
            ballMove script = novaBola.GetComponent<ballMove>();

            if (script != null)
            {
                script.Lancar();
            }
            else
            {
                Debug.LogError(
                    "O Prefab da bola não possui o script ballMove!"
                );
            }
        }
    }
}