using UnityEngine;

public class ballMove : MonoBehaviour
{
    public float speed = 8f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();

        // Ângulo aleatório para baixo: entre -45° e 45° em relação a "reto para baixo"
        float angulo = Random.Range(-45f, 45f);
        Vector2 direcao = Quaternion.Euler(0, 0, angulo) * Vector2.down;

        rb.linearVelocity = direcao.normalized * speed;
    }

    void OnCollisionEnter2D(Collision2D coll)
    {
        if (coll.gameObject.CompareTag("Brick"))
        {
            Destroy(coll.gameObject);
        }
    }

    void FixedUpdate()
    {
    // Mantém a velocidade sempre no mesmo valor, só a direção muda com as colisões
    rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }
}