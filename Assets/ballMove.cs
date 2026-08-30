using UnityEngine;

public class ballMove : MonoBehaviour
{
    public float speed = 5f;
    private Rigidbody2D rb;

    void Start()
    {
        rb = GetComponent<Rigidbody2D>();
        Lancar();
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
        rb.linearVelocity = rb.linearVelocity.normalized * speed;
    }

    // Lança a bola numa direção aleatória para baixo.
    // Público para poder ser chamado de novo pelo BottomTrigger depois de perder uma vida.
    public void Lancar()
    {
        float angulo = Random.Range(-45f, 45f);
        Vector2 direcao = Quaternion.Euler(0, 0, angulo) * Vector2.down;
        rb.linearVelocity = direcao.normalized * speed;
    }
}