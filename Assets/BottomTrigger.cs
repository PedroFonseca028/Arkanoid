using System.Collections;
using UnityEngine;

public class BottomTrigger : MonoBehaviour
{
    public float tempoEspera = 2f;

    void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Ball"))
        {
            GameControl.instance.PerderVida();
            StartCoroutine(ResetarBola(other));
        }
    }

    IEnumerator ResetarBola(Collider2D other)
    {
        Rigidbody2D rb = other.GetComponent<Rigidbody2D>();
        ballMove script = other.GetComponent<ballMove>();

        // Para a bola e reposiciona ela imediatamente
        rb.linearVelocity = Vector2.zero;
        other.transform.position = new Vector3(0, 0, 0); // ajuste pra onde a bola deve nascer

        // Espera o tempo definido, sem travar o resto do jogo
        yield return new WaitForSeconds(tempoEspera);

        // Depois de esperar, lança a bola de novo numa direção aleatória
        script.Lancar();
    }
}