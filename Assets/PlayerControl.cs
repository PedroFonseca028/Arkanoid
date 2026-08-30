using UnityEngine;

public class PlayerControl : MonoBehaviour
{

    public KeyCode moveLeft = KeyCode.A;    // Move a nave para a esquerda
    public KeyCode moveRight = KeyCode.D;   // Move a nave para a direita
    public float speed = 10.0f;             // Define a velocidade da nave

    private Rigidbody2D rb2d;               // Define o corpo rígido 2D que representa a nave

    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
    }

    // Update is called once per frame
    void Update()
    {
        var vel = rb2d.linearVelocity;              // Acessa a velocidade da nave
        if (Input.GetKey(moveLeft)) {                // Velocidade da nave para ir para a esquerda
            vel.x = -speed;
        }
        else if (Input.GetKey(moveRight)) {          // Velocidade da nave para ir para a direita
            vel.x = speed;
        }
        else {
            vel.x = 0;                               // Velocidade para manter a nave parada
        }
        rb2d.linearVelocity = vel;                   // Atualiza a velocidade da nave

        // O limite da nave agora é controlado só pela colisão física com as paredes
    }
}